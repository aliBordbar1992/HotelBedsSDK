using System.Net.Http;

namespace HotelBeds.Api.Activities
{
    public class Paths
    {
        public class ActivitySearch : ApiPathsBase
        {
            public ActivitySearch()
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = "activities";
            }
        }
        public class ActivityDetails : ApiPathsBase
        {
            private ActivityDetails(string endpoint)
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = endpoint;
            }

            public static ActivityDetails Simple()
            {
                return new ActivityDetails("activities/details");
            }

            public static ActivityDetails Full()
            {
                return new ActivityDetails("activities/details/full");
            }
        }
        public class BookingConfirm : ApiPathsBase
        {
            public BookingConfirm()
            {
                HttpMethod = new HttpMethod("PUT");
                Endpoint = "bookings";
            }
        }
        public class BookingPreConfirm : ApiPathsBase
        {
            public BookingPreConfirm()
            {
                HttpMethod = new HttpMethod("PUT");
                Endpoint = "bookings/preconfirm";
            }
        }
        public class BookingReConfirm : ApiPathsBase
        {
            public BookingReConfirm()
            {
                HttpMethod = new HttpMethod("PUT");
                Endpoint = "bookings/reconfirm";
            }
        }
        public class Cancel : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string Reference => "{{reference}}";
                public string SimulationOrCancel => "{{SIMULATION or CANCELLATION}}";
            }

            public Cancel()
            {
                HttpMethod = new HttpMethod("DELETE");
                Endpoint = "bookings/{{lang}}/{{reference}}?cancellationFlag={{SIMULATION or CANCELLATION}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
        public class BookingDetailsByBookingReference : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string BookingReference => "{{bookingReference}}";
            }

            public BookingDetailsByBookingReference()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "bookings/{{lang}}/{{bookingReference}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
        public class BookingDetailsByClientReference : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string ClientReference => "{{clientReference}}";
                public string HolderName => "{{holderName}}";
                public string HolderSurname => "{{holderSurname}}";
                public string StartDate => "{{startDate}}";
                public string EndDate => "{{endDate}}";
            }

            public BookingDetailsByClientReference()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "bookings/{{lang}}/{{clientReference}}/{{holderName}}/{{holderSurname}}/{{startDate}}/{{endDate}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
        public class BookingList : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string FilterType => "{{filter_type}}";
                public string IncludeCancelled => "{{cancelled}}";
                public string StartDate => "{{startDate}}";
                public string EndDate => "{{endDate}}";
            }

            public BookingList()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "bookings/{{lang}}?start={{startDate}}&end={{endDate}}&includedCancelled={{cancelled}&filterType={{filter_type}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
        public class BookingModificationAddRequest : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string Reference => "{{reference}}";
            }

            public BookingModificationAddRequest()
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = "bookings/add/{{lang}}/{{reference}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
        public class BookingModificationModifyRequest : ApiPathsBase
        {
            public class Params
            {
                public string Lang => "{{lang}}";
                public string Reference => "{{reference}}";
            }

            public BookingModificationModifyRequest()
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = "bookings/modify/{{lang}}/{{reference}}";
            }

            public Params GetParams()
            {
                return new Params();
            }
        }
    }
}