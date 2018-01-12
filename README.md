# GeoWeather
A simple library to retrieve publically-available geospacial and weather data in the USA.

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
```

