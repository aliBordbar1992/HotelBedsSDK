using System.Net.Http;

namespace HotelBeds.Api.TransferContents
{
    public class Paths
    {
        public class Routes : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Destination => "{{DESTINATION}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Routes()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "routes?fields={{FIELDS}}&destinationCode={{DESTINATION}}&OFFSET={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Pickups : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Pickups()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "pickups?fields={{FIELDS}}&language={{LANG}}&codes={{CODES}}&OFFSET={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Hotels : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Countries => "{{COUNTRIES}}";
                public string Destinations => "{{DESTINATIONS}}";
                public string Giatas => "{{GIATAS}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Hotels()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "hotels?fields={{FIELDS}}&language={{LANG}}&countryCodes={{COUNTRIES}}&destinationCodes={{DESTINATIONS}}&codes={{CODES}}&giataCodes={{GIATAS}}&OFFSET={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Currencies : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Currencies()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "currencies?currencies={{FIELDS}}&language={{LANG}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class MasterTransferType : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public MasterTransferType()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "currencies?transferTypes={{FIELDS}}&language={{LANG}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class MasterCategories : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public MasterCategories()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "currencies?categories={{FIELDS}}&language={{LANG}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class MasterVehicles : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public MasterVehicles()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "currencies?vehicles={{FIELDS}}&language={{LANG}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Countries : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Countries()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "locations/countries?Countries={{FIELDS}}&language={{LANG}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Destinations : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Country => "{{COUNTRY}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Destinations()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "locations/destinations?fields={{FIELDS}}&language={{LANG}}&countryCodes={{COUNTRY}}	&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
        public class Terminals : ApiPathsBase
        {
            public class Params
            {
                public string Fields => "{{FIELDS}}";
                public string Language => "{{LANG}}";
                public string Country => "{{COUNTRY}}";
                public string Codes => "{{CODES}}";
                public string Offset => "{{OFFSET}}";
                public string Limit => "{{LIMIT}}";
            }

            public Params GetParams()
            {
                return new Params();
            }

            public Terminals()
            {
                HttpMethod = new HttpMethod("GET");
                Endpoint = "locations/terminals?fields={{FIELDS}}&language={{LANG}}&countryCodes={{COUNTRY}}&codes={{CODES}}&offset={{OFFSET}}&limit={{LIMIT}}";
            }
        }
    }
}