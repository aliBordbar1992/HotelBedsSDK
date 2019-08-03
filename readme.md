# HotelBeds SDK

HotelBeds SDK is a wrapper for the HotelBeds [APITude](https://developer.hotelbeds.com) and currently implements [Activities BOOKINGAPI](https://developer.hotelbeds.com/docs/read/apitude_activities_booking) and [Transfers BOOKINGAPI](https://developer.hotelbeds.com/docs/read/apitude_transfers_booking). 



# Features

  - .NET Core compatible
  - Request builder helpers
  - Easily swap between production and test api




### Usage

Easily integrate this library with your .NET core app. In your ```startup.cs```:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    //if you want to use ActivitiesBooking
    services.AddActivityApiClient("your api key", "your secret");
    
    //if you want to use TransfersBooking
    services.AddTransferApiClient("your api key", "your secret");
    ...
}
```

and if you want to use test api urls in development, just do as following:
```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    //...
    if (env.IsDevelopment())
    {
        //...
        app.UseActivityTestApi();
        app.UseTransferTestApi();
    }
    //...
}
```

In your controller, just inject ```IActivityApi``` to use activities, and ```ITransferApi``` to transfers.
