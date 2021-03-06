# GeoWeather
A simple library to retrieve publically-available geospacial and weather data in the USA.
Uses the [BotCommon](https://github.com/GuMiner/BotCommon) library to simplify sending weather responses to [Bot Framework](https://dev.botframework.com/) bots.

## APIs
### Geospacial
```csharp
using GeoWeather.Location;

LocationQuerier querier = new LocationQuerier("YourBingMapsAPIKey");
GeoCoordinate location = await querier.GetLocationAsync("Miami, FL");
```

### Weather Stations
```csharp
using GeoWeather.Stations;

// Using the coordinate from the Geospacial example...
Station closestWeatherStation = StationLocator.FindClosestStation(location);

// Each station contains a callsign, name, and location.
```
### Weather Data
```csharp
using BotCommon;
using GeoWeather;
using GeoWeather.Layers;
using System;

WeatherSettings settings = new WeatherSettings(); // Defaults to a NOAA station and two layers.
IStore dataStore = ... // Created from the https://github.com/GuMiner/BotCommon library

// Get a weather image (as a SAS URI that will expire in approximately one year).
AttachmentResponse weatherImageAsABotResponseMessage = 
    await LayerRetriever.GetRadarImageAsync(settings, dataStore, "weather-blob-container", TimeSpan.FromDays(365));
```

