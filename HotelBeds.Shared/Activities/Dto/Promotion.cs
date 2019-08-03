using System;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Promotion
    {
        public string Code { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ImagePath { get; set; }

        public Promotion()
        {
        }

        public Promotion(int order, string code, string imagePath, string description, string name, DateTime dateFrom, DateTime dateTo)
        {
            Order = order;
            Code = code;
            ImagePath = imagePath;
            Description = description;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public Promotion(int order, string code)
        {
            Order = order;
            Code = code;
        }

        public override string ToString()
        {
            return this.ToJsonString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + Code.GetHashCode();
            hash = 97 * hash + Order.GetHashCode();
            hash = 97 * hash + Name.GetHashCode();
            hash = 97 * hash + Description.GetHashCode();
            hash = 97 * hash + DateFrom.GetHashCode();
            hash = 97 * hash + DateTo.GetHashCode();
            hash = 97 * hash + ImagePath.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Promotion other = (Promotion)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Order.Equals(other.Order)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Description.Equals(other.Description)) return false;
            if (!DateFrom.Equals(other.DateFrom)) return false;
            if (!DateTo.Equals(other.DateTo)) return false;
            if (!ImagePath.Equals(other.ImagePath)) return false;

            return true;
        }


    }
}