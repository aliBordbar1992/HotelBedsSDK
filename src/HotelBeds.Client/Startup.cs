using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBeds.Api.Activities.Extensions;
using HotelBeds.Api.Transfer.Extensions;
using HotelBeds.Client.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBeds.Client
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddActivityApiClient("9z8f4jry8dhuk5j65c58sgha", "FDBDYq3b2Y");
            services.AddTransferApiClient("9z8f4jry8dhuk5j65c58sgha", "FDBDYq3b2Y");
            services.AddContext();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseActivityTestApi();
                app.UseTransferTestApi();
            }

            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
