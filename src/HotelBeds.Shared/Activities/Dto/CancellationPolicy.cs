using System;

namespace HotelBeds.Shared.Activities.Dto
{
    public class CancellationPolicy : IComparable
    {
        public string DateFrom { get; set; }
        public decimal? Amount { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is CancellationPolicy)) return false;

            CancellationPolicy fee = (CancellationPolicy)obj;
            if ((DateFrom != null  && fee.DateFrom == null)
                || (DateFrom == null  && fee.DateFrom != null)
                || !DateFrom.Equals(fee.DateFrom))
                return false;


            if ((Amount != null && fee.Amount == null)
                || (Amount == null && fee.Amount != null)
                || (Amount != fee.Amount))
                return false;


            return true;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is CancellationPolicy)) return -1;

            CancellationPolicy fee = (CancellationPolicy)obj;
            if (DateFrom != null && fee.DateFrom != null)
                return String.Compare(DateFrom, fee.DateFrom, StringComparison.Ordinal);

            if (DateFrom != null)
                return -1;

            return 1;
        }
    }
}