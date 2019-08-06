using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBeds.Api.TransferContents.Extensions
{
    public static class TransferContentApiClientExtensions
    {
        public static void AddTransferContentApiClient(this IServiceCollection serviceCollection, string apiKey,  string secret)
        {
            string baseUrl = "https://api.test.hotelbeds.com/transfer-cache-api";
            var url = new TransferContentApiBaseUrl {BaseUrl = baseUrl};
            serviceCollection.AddTransient<ITransferContentApiBaseUrl>(c => url);
            serviceCollection.AddTransient<ITransferContentVersionSelector>(c => new TransferContentVersionSelector());
            serviceCollection.AddTransient<IHotelBedsApiClient, ApiClient>(x => new ApiClient(apiKey, secret));
            serviceCollection.AddTransient<ITransferContentApi, TransferContentApi>();
        }

        public static void UseTransferContentTestApi(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransferContentTestApiMiddleware>();
        }
    }

    public class TransferContentTestApiMiddleware
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly RequestDelegate _next;

        public TransferContentTestApiMiddleware(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public TransferContentTestApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            string baseUrl = "https://api.test.hotelbeds.com/transfer-cache-api";
            var url = (ITransferContentApiBaseUrl)serviceProvider.GetService(typeof(ITransferContentApiBaseUrl));
            url.SetUrl(baseUrl);

            await _next(httpContext);
        }
    }
}