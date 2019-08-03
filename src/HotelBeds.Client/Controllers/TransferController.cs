using System;
using System.Collections.Generic;
using System.Linq;
using HotelBeds.Api.Transfer;
using HotelBeds.Client.Data;
using HotelBeds.Shared.Transfer.Domain;
using HotelBeds.Shared.Transfer.Dto;
using HotelBeds.Shared.Transfer.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Booking_Db = HotelBeds.Client.Data.Models.Booking;

namespace HotelBeds.Client.Controllers
{
    [Route("api/transfer/[action]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferApi _transferApi;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Booking_Db> _bookingRepository;

        public TransferController(ITransferApi transferApi, IUnitOfWork unitOfWork, IRepository<Booking_Db> bookingRepository)
        {
            _transferApi = transferApi;
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        [Route("/api/transfer/availability/{language}/from/{fromType}/{fromCode}/to/{toType}/{toCode}/{outbound}/{adults}/{children}/{infants}")]
        public JsonResult Availability(
            string language,
            string fromType,
            string fromCode,
            string toType,
            string toCode,
            string outbound,
            int adults,
            int children,
            int infants
        )
        {
            var req = new AvailabilityRequest(language, TransferPointType.FromCode(fromType), fromCode,
                TransferPointType.FromCode(toType), toCode, outbound, adults, children, infants);
            var response = _transferApi.Availability(req);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("/api/transfer/availability/{language}/from/{fromType}/{fromCode}/to/{toType}/{toCode}/{outbound}/{inbound}/{adults}/{children}/{infants}")]
        public JsonResult Availability(
            string language,
            string fromType,
            string fromCode,
            string toType,
            string toCode,
            string outbound,
            string inbound,
            int adults,
            int children,
            int infants
        )
        {
            var req = new AvailabilityRequest(language, TransferPointType.FromCode(fromType), fromCode,
                TransferPointType.FromCode(toType), toCode, outbound, inbound, adults, children, infants);
            var response = _transferApi.Availability(req);

            return new JsonResult(response);
        }


        [HttpPost]
        [Route("/api/transfer/booking")]
        public JsonResult Confirm([FromBody] ConfirmRequest request)
        {
            var response = _transferApi.Confirm(request);

            if (response.Bookings == null) return new JsonResult(response);

            Save(response.Bookings);

            try
            {
                var vouchers = _transferApi.GenerateVoucher(response.Bookings);
                return new JsonResult(vouchers, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception e)
            {
                return new JsonResult(response);
            }
        }


        private void Save(List<Booking> responseBooking)
        {
            foreach (var booking in responseBooking)
            {
                var b = new Booking_Db
                {
                    ClientReference = booking.ClientReference,
                    CreationDate = DateTime.Now,
                    HolderName = booking.Holder.Name,
                    HolderSurname = booking.Holder.Surname,
                    Reference = booking.Reference,
                    Status = booking.Status.GetCode()
                };

                _bookingRepository.Insert(b);
            }
            _unitOfWork.SaveChanges();
        }


        [HttpDelete]
        [Route("/api/transfer/booking/cancel/{language}/{reference}")]
        public JsonResult CancelBooking(string language, string reference)
        {
            var response = _transferApi.Cancel(language, reference);

            if (response.Error != null) return new JsonResult(response);

            UpdateBookingStatus(reference, response.Bookings.First(x => x.Reference == reference).Status.GetCode());

            return new JsonResult(response);
        }

        private void UpdateBookingStatus(string reference, string status)
        {
            var book = _bookingRepository.Query().FirstAsync(x => x.Reference == reference).Result;
            book.Status = status;

            _unitOfWork.SaveChanges();
        }

        [HttpGet]
        [Route("/api/transfer/booking/voucher/{language}/{reference}")]
        public JsonResult Voucher(string language, string reference)
        {
            var response = _transferApi.Details(language, reference);

            var vouchers = _transferApi.GenerateVoucher(response.Bookings);
            return new JsonResult(vouchers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }



        [HttpGet]
        [Route("/api/transfer/booking/details/{language}/{reference}")]
        public JsonResult BookingDetails(string language, string reference)
        {
            var response = _transferApi.Details(language, reference);

            return new JsonResult(response);
        }
    }
}