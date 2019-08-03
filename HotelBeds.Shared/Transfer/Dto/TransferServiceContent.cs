using System.Collections.Generic;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferServiceContent
    {
        public Category Category { get; set; }
        public List<CustomerTransferTimeInfo> CustomerTransferTimeInfo { get; set; }
        public List<Image> Images { get; set; }
        public List<CustomerTransferTimeInfo> SupplierTransferTimeInfo { get; set; }
        public List<TransferDetailInfo> TransferDetailInfo { get; set; }
        public List<TransferRemark> TransferRemarks { get; set; }
        public Category Vehicle { get; set; }
    }
}