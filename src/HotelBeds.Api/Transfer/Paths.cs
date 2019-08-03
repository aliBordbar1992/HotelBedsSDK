using System.Net.Http;

namespace HotelBeds.Api.Transfer
{
    public class Paths
    {
        public class AvailabilityNoInbound : ApiPathsBase
        {
            public class Params
            {
                public string Language => "{{language}}";
                public string FromType => "{{fromType}}";
                public string FromCode => "{{fromCode}}";
                public string ToType => "{{toType}}";
                public string ToCode => "{{toCode}}";
                public string Outbound => "{{outbound}}";
                public string Adults => "{{adults}}";
                public string Children => "{{children}}";
                public string Infants => "{{infants}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public AvailabilityNoInbound()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "availability/{{language}}/from/{{fromType}}/{{fromCode}}/to/{{toType}}/{{toCode}}/{{outbound}}/{{adults}}/{{children}}/{{infants}}";
            }
        }
        public class Availability : ApiPathsBase
        {
            public class Params
            {
                public string Language => "{{language}}";
                public string FromType => "{{fromType}}";
                public string FromCode => "{{fromCode}}";
                public string ToType => "{{toType}}";
                public string ToCode => "{{toCode}}";
                public string Outbound => "{{outbound}}";
                public string Inbound => "{{inbound}}";
                public string Adults => "{{adults}}";
                public string Children => "{{children}}";
                public string Infants => "{{infants}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Availability()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "availability/{{language}}/from/{{fromType}}/{{fromCode}}/to/{{toType}}/{{toCode}}/{{outbound}}/{{inbound}}/{{adults}}/{{children}}/{{infants}}";
            }
        }

        public class AvailabilityRoutes : ApiPathsBase
        {
            public class Params
            {
                public string Language => "{{language}}";
                public string Adults => "{{adults}}";
                public string Children => "{{children}}";
                public string Infants => "{{infants}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public AvailabilityRoutes()
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = "availability/routes/{{language}}/{{adults}}/{{children}}/{{infants}}";
            }
        }

        public class BookingConfirm : ApiPathsBase
        {
            public BookingConfirm()
            {
                HttpMethod = new HttpMethod("POST");
                Endpoint = "booking";
            }
        }

        public class ConfirmedBookingDetails : ApiPathsBase
        {
            public class Params
            {
                public string Language => "{{language}}";
                public string Reference => "{{reference}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public ConfirmedBookingDetails()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "booking/{{language}}/reference/{{reference}}";
            }
        }

        public class CancelBooking : ApiPathsBase
        {
            public class Params
            {
                public string Language => "{{language}}";
                public string Reference => "{{reference}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public CancelBooking()
            {
                HttpMethod = new HttpMethod("DELETE");
                Endpoint = "booking/{{language}}/reference/{{reference}}";
            }
        }


    }
}