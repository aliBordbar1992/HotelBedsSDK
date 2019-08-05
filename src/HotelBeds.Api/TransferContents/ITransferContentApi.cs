using HotelBeds.Shared.TransferContent.Request;
using HotelBeds.Shared.TransferContent.Response;

namespace HotelBeds.Api.TransferContents
{
    public interface ITransferContentApi
    {
        /// <summary>
        /// This method is used to obtain a Routes portfolio.
        /// </summary>
        /// <param name="destinationCode">Atlas destination code</param>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Routes provides information of the routes traveled by the transfers</returns>
        RouteResponse Routes(string destinationCode, string fields = "ALL", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a Pickups portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">Comma separated list of Pickup codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Pickups provides information of the available pickup points</returns>
        PickupResponse Pickups(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a HOTELS portfolio.
        /// </summary>
        /// <param name="request">The request to send via url parameters</param>
        /// <returns>The response of Hotels provides information of the hotels</returns>
        HotelResponse Hotels(HotelRequest request);


        /// <summary>
        /// This method is used to obtain a Currencies portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">comma separated list of ISO 4217 (3 digit) currency codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Currencies provides key information of the accepted currencies</returns>
        CurrencyResponse Currencies(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a MasterTransferTypes portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">Comma separated list of Master Types codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Categories provides information of the vehicle categories used by the transfers</returns>
        MasterTransferTypeResponse TransferType(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a MasterCategories portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">Comma separated list of Master Category codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Categories provides information of the vehicle categories used by the transfers</returns>
        MasterCategoriesResponse Categories(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a MasterVehicles portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">Comma separated list of Master Vehicle codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Vehicles provides information of the vehicles traveled by the transfers</returns>
        MasterVehiclesResponse Vehicles(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a Countries portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="codes">comma separated list of ISO 3166 (2 digit) country codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Vehicles provides information of the vehicles traveled by the transfers</returns>
        CountriesResponse Countries(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a Destinations portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="countryCode">comma separated list of ISO 3166 (2 digit) country codes</param>
        /// <param name="codes">comma separated list of destination codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Destinations provides information of the available destinations.</returns>
        CountriesResponse Destinations(string fields = "ALL", string language = "en", string countryCode = "", string codes = "", int offset = 0, int limit = 0);


        /// <summary>
        /// This method is used to obtain a TERMINALS portfolio.
        /// </summary>
        /// <param name="fields">Comma separated list of response fields to return. 
        /// Default ALL, retrieves all fields</param>
        /// <param name="language">ISO 639-1 (2 digit) Language code. 
        /// Default En</param>
        /// <param name="countryCode">comma separated list of ISO 3166 (2 digit) country codes</param>
        /// <param name="codes">comma separated list of terminal codes</param>
        /// <param name="offset">It's the position in the data set of a particular record.
        /// By specifying offset, you retrieve a subset of records starting with the offset value. 
        /// Default 0, retrieves all items</param>
        /// <param name="limit">Allows you to set the number of objects returned in one page.
        /// Default 0, retrieves all items</param>
        /// <returns>The response of Destinations provides information of the available destinations.</returns>
        TerminalsResponse Terminals(string fields = "ALL", string language = "en", string countryCode = "", string codes = "", int offset = 0, int limit = 0);
    }
}