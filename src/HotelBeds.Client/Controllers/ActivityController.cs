using System;
using System.Collections.Generic;
using HotelBeds.Api.Activities;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Client.Data;
using HotelBeds.Client.Dto;
using HotelBeds.Client.Dto.Response;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Booking = HotelBeds.Shared.Activities.Dto.Booking;
using Booking_Db = HotelBeds.Client.Data.Models.Booking;

namespace HotelBeds.Client.Controllers
{
    [Route("api/activity/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityApi _activityApi;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Booking_Db> _bookingRepository;

        public ActivityController(IActivityApi activityApi, IUnitOfWork unitOfWork, IRepository<Booking_Db> bookingRepository)
        {
            _activityApi = activityApi;
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        public JsonResult Search([FromBody] SearchRequest items)
        {
            List<ActivitySearchFilterItemList> fList = ExtractFilters(items.Filters);
            var request = new SearchRequestBuilder(fList, items.From, items.To).Build();

            var response = _activityApi.Search(request);
            if (response.Errors != null) return new JsonResult(response);

            SearchResponse result = SearchResponse.ExtractFrom(response);

            return new JsonResult(result);
        }

        private List<ActivitySearchFilterItemList> ExtractFilters(List<Filter> filters)
        {
            List<ActivitySearchFilterItemList> fList = new List<ActivitySearchFilterItemList>();
            foreach (var filter in filters)
            {
                var newFilter = new ActivitySearchFilterItemList();

                foreach (var filterItem in filter.FilterItems)
                {
                    if (filterItem.Latitude.HasValue && filterItem.Longitude.HasValue)
                    {
                        newFilter.SearchFilterItems.Add(new ActivitySearchFilterItem(
                            ActivityFilterType.FromCode(filterItem.Type), filterItem.Latitude.Value,
                            filterItem.Longitude.Value));
                    }
                    else
                    {
                        newFilter.SearchFilterItems.Add(
                            new ActivitySearchFilterItem(ActivityFilterType.FromCode(filterItem.Type),
                                filterItem.Value));
                    }
                }

                fList.Add(newFilter);
            }

            //var t  = new Api.Helpers.Activity.SearchRequestFilterBuilder()
            //    .With().ListOf(filters)
            //    .WithItems(x => x.FilterItems)
            //    .WithProperties(x => x.Type, x => x.Value, x => x.Latitude, x => x.Longitude)
            //    .Build();

            return fList;
        }



        [HttpPost]
        public JsonResult Details([FromBody] ActivityDetailRequest request)
        {
            var response = _activityApi.Details(request);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("/api/activity/details/full")]
        public JsonResult FullDetails([FromBody] ActivityDetailRequest request)
        {
            var response = _activityApi.FullDetails(request);

            return new JsonResult(response);
        }


        [HttpPut]
        public JsonResult Confirm([FromBody] BookingConfirmRequest request)
        {
            var response = _activityApi.ConfirmBooking(request);

            if (response.Booking == null) return new JsonResult(response);

            Save(response.Booking);

            try
            {
                var voucher = _activityApi.GenerateVoucher(response.Booking);
                return new JsonResult(voucher, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception e)
            {
                return new JsonResult(response);
            }
        }

        [HttpGet]
        [Route("/api/activity/booking/voucher/{language}/{reference}")]
        public JsonResult Voucher(string language, string reference)
        {
            var response = _activityApi.BookingDetails(language, reference);

            var voucher = _activityApi.GenerateVoucher(response.Booking);
            return new JsonResult(voucher, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private void Save(Booking responseBooking)
        {
            var b = new Booking_Db
            {
                ClientReference = responseBooking.ClientReference,
                CreationDate = DateTime.Now,
                HolderName = responseBooking.Holder.Name,
                HolderSurname = responseBooking.Holder.Surname,
                Reference = responseBooking.Reference,
                Status = responseBooking.Status.ToString()
            };

            _bookingRepository.Insert(b);
            _unitOfWork.SaveChanges();
        }

        [HttpGet]
        [Route("/api/activity/booking/details/{language}/{reference}")]
        public JsonResult BookingDetails(string language, string reference)
        {
            var response = _activityApi.BookingDetails(language, reference);

            return new JsonResult(response);
        }

        [HttpDelete]
        [Route("/api/activity/booking/cancel/{language}/{reference}")]
        public JsonResult CancelBooking(string language, string reference, [FromQuery(Name = "cancellationFlag")] string cancellationFlag)
        {
            var simulate = cancellationFlag == null || !cancellationFlag.Equals("CANCELLATION");

            var response = _activityApi.CancelBooking(language, reference, simulate);

            if (response.Errors != null) return new JsonResult(response);

            UpdateBookingStatus(reference, response.Booking.Status.ToString());

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("/api/activity/booking/modify/{language}/{reference}")]
        public JsonResult BookingModify(string language, string reference, [FromBody] BookingModificationModifyRequest request)
        {
            var response = _activityApi.ModifyBookingModifyService(request, language, reference);

            return new JsonResult(response);
        }

        private void UpdateBookingStatus(string reference, string status)
        {
            var book = _bookingRepository.Query().FirstAsync(x => x.Reference == reference).Result;
            book.Status = status;

            _unitOfWork.SaveChanges();
        }
    }
}