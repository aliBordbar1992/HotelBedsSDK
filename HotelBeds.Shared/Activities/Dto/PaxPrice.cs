using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PaxPrice
    {
        [JsonConverter(typeof(EnumTypeConverter<PaxType , PaxType >))]
        public PaxType PaxType { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal BoxOfficeAmount { get; set; }
        public bool MandatoryApplyAmount { get; set; }


        public override int GetHashCode()
        {
            int hash = 3;
            hash = 17 * hash + PaxType.GetHashCode();
            hash = 17 * hash + AgeFrom.GetHashCode();
            hash = 17 * hash + AgeTo.GetHashCode();
            hash = 17 * hash + Amount.GetHashCode();
            hash = 17 * hash + NetAmount.GetHashCode();
            hash = 17 * hash + BoxOfficeAmount.GetHashCode();
            hash = 17 * hash + MandatoryApplyAmount.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            PaxPrice other = (PaxPrice)obj;
            if (PaxType != other.PaxType) return false;
            if (!AgeFrom.Equals(other.AgeFrom)) return false;
            if (!AgeTo.Equals(other.AgeTo)) return false;
            if (!Amount.Equals(other.Amount)) return false;
            if (!NetAmount.Equals(other.NetAmount)) return false;
            if (!BoxOfficeAmount.Equals(other.BoxOfficeAmount)) return false;
            if (!MandatoryApplyAmount.Equals(other.MandatoryApplyAmount)) return false;

            return true;
        }


    }
}