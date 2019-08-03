using System;
using System.Threading.Tasks;
using HotelBeds.Api.Activities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBeds.Api.Transfer.Extensions
{
    public static class TransferApiClientExtensions
    {
        public static void AddTransferApiClient(this IServiceCollection serviceCollection, string apiKey,  string secret)
        {
            string baseUrl = "https://api.hotelbeds.com/transfer-api";
            var url = new TransferApiBaseUrl {BaseUrl = baseUrl};
            serviceCollection.AddTransient<ITransferApiBaseUrl>(c => url);
            serviceCollection.AddTransient<ITransferVersionSelector>(c => new TransferApiVersion());
            serviceCollection.AddTransient<IHotelBedsApiClient, ApiClient>(x => new ApiClient(apiKey, secret));
            serviceCollection.AddTransient<ITransferApi, TransferApi>();
        }

        public static void UseTransferTestApi(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransferTestApiMiddleware>();
        }
    }

    public class TransferTestApiMiddleware
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly RequestDelegate _next;

        public TransferTestApiMiddleware(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public TransferTestApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            string baseUrl = "https://api.test.hotelbeds.com/transfer-api";
            var url = (ITransferApiBaseUrl)serviceProvider.GetService(typeof(ITransferApiBaseUrl));
            url.SetUrl(baseUrl);

            await _next(httpContext);
        }
    }
}