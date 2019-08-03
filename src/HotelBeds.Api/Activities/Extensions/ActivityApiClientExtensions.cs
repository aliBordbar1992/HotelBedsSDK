using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBeds.Api.Activities.Extensions
{
    public static class ActivityApiClientExtensions
    {
        public static void AddActivityApiClient(this IServiceCollection serviceCollection, string apiKey,  string secret)
        {
            string baseUrl = "https://api.hotelbeds.com/activity-api";
            var url = new ActivityApiBaseUrl {BaseUrl = baseUrl};
            serviceCollection.AddTransient<IActivityApiBaseUrl>(c => url);
            serviceCollection.AddTransient<IActivityVersionSelector>(c => new ActivityApiVersion(ActivityApiVersion.Versions.V3));
            serviceCollection.AddTransient<IHotelBedsApiClient, ApiClient>(x => new ApiClient(apiKey, secret));
            serviceCollection.AddTransient<IActivityApi, ActivityApi>();
        }

        public static void UseActivityTestApi(this IApplicationBuilder app)
        {
            app.UseMiddleware<ActivityTestApiMiddleware>();
        }
    }

    public class ActivityTestApiMiddleware
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly RequestDelegate _next;

        public ActivityTestApiMiddleware(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public ActivityTestApiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            string baseUrl = "https://api.test.hotelbeds.com/activity-api";
            var url = (IActivityApiBaseUrl)serviceProvider.GetService(typeof(IActivityApiBaseUrl));
            url.SetUrl(baseUrl);

            await _next(httpContext);
        }
    }
}