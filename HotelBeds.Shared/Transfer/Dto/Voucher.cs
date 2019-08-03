using System.Collections.Generic;
using System.Linq;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Voucher
    {
        public Voucher(Booking booking)
        {
            Reference = booking.Reference;
            ConfirmationDate = booking.CreationDate.ToString();
            Remark = booking.Remark;
            Holder = booking.Holder;
            VoucherDetails = VoucherDetail.Generate(booking.Transfers);
        }

        public string Reference { get; set; }
        public string ConfirmationDate { get; set; }
        public string Remark { get; set; }
        public Pax Holder { get; set; }
        public List<VoucherDetail> VoucherDetails { get; set; }
    }

    public class VoucherDetail
    {
        private VoucherDetail(TransferService transfer)
        {
            Pickup = transfer.PickupInformation.Pickup;
            Paxes = new List<Pax>();
            Paxes = transfer.Paxes;
            EmergencyNumber = transfer.SourceMarketEmergencyNumber;
        }


        public Pickup Pickup { get; set; }
        public List<Pax> Paxes { get; set; }
        public string EmergencyNumber { get; set; }

        public static List<VoucherDetail> Generate(List<TransferService> bookingTransfers)
        {
            var result = new List<VoucherDetail>();
            foreach (var transfer in bookingTransfers)
            {
                result.Add(new VoucherDetail(transfer));
            }

            return result;
        }
    }
}