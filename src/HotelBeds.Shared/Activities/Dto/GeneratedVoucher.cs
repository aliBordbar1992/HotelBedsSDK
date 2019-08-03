using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class GeneratedVoucher
    {
        /*
⦁	ReferenceNumber         | Returned in “/booking.reference”.
⦁	TicketFullName/Activity | Returned in ”/booking.activities.name”.
⦁	BookingConfirmDate      | Returned in “/booking.creationDate”.
⦁	LeadPaxName             | Returned in “/holder”.
⦁	From                    | Returned in FROM “booking.activities.dateFrom” TO “/booking.activities.dateTo”.
⦁	To                      | Returned in FROM “booking.activities.dateFrom” TO “/booking.activities.dateTo”.
⦁	ModalityName            | Returned in “/booking.activities.modality.name”.
⦁	PaxDistribution         | Returned in “/booking.activities.paxes”.
⦁	ChildrenAges            | if (/booking.activities.paxes[].age <18) display age in voucher.
⦁	Destination             | Returned in “/booking.activities.contactInfo.country.destinations.name”.
⦁	Remarks                 | Returned in “/booking.activities.comments[].text”(WHERE TYPE ="CONTRACT_REMARKS")”.
⦁	SupplierInfo            | (Name, Address and Reference of Supplier if shown in the logs) Returned in ”booking.activities.providerInformation”.
⦁	SessionSelected         | Returned in “/booking.activities.modality.rates.rateDetails.session.name”.
⦁	LanguageSelected        | Returned in “/booking.activities.modality.rates.rateDetails.language.name”.
⦁	PickupPoint             | (only for Excursions, Not Implemented for the moment) Returned in “/booking.activities.pickup[]”.
⦁	Barcode/QR code         | In case of returning the “/booking.activities.vouchers[]” != null.
⦁	“Bookable and Payable by” information | Returned in “/booking.activities.supplier”  Bookable and payable thru “/booking.activities.supplier.name” with VAT “/booking.activities.supplier.vatNumber”.
         */

        public GeneratedVoucher(Booking booking)
        {
            ReferenceNumber = booking.Reference;
            BookingConfirmDate = booking.CreationDate;
            LeadPaxName = $"{booking.Holder.Name} {booking.Holder.Surname}";
            Activities = new List<VoucherActivity>();

            foreach (var activity in booking.Activities)
            {
                Activities.Add(new VoucherActivity(activity));
            }
        }


        public string ReferenceNumber { get; }
        public DateTime BookingConfirmDate { get; }
        public string LeadPaxName { get; }
        public List<VoucherActivity> Activities { get; }
    }
}