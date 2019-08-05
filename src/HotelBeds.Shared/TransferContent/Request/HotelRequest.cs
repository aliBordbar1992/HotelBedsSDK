namespace HotelBeds.Shared.TransferContent.Request
{
    public class HotelRequest
    {
        public string Fields { get; }
        public string Language { get; }
        public string CountryCodes { get; set; }
        public string DestinationCodes { get; set; }
        public string Codes { get; set; }
        public string GiataCodes { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }


        /// <summary>
        /// The Hotel request for Transfer Content API Hotels.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="countryCodes">Comma separated ISO 3166 (2 digit) country codes</param>
        /// <param name="destinationCodes">Comma separated list of ATLAS destination codes</param>
        /// <param name="codes">Comma separated list of ATLAS hotel codes</param>
        /// <param name="giataCodes">Comma separated list of GIATA hotel codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        public HotelRequest(string fields = "ALL", string language = "en", string countryCodes = "", string destinationCodes = "", string codes = "", string giataCodes = "", int offset = 0, int limit = 0)
        {
            Fields = fields;
            Language = language;
            CountryCodes = countryCodes;
            DestinationCodes = destinationCodes;
            Codes = codes;
            GiataCodes = giataCodes;
            Offset = offset;
            Limit = limit;
        }

    }
}