namespace SpaceTraders.Data.Services;

public class LocationService : BaseService
{
    public LocationService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Location>> GetSystemLocations()
    {
        var response = await HttpClient.GetAsync("https://api.spacetraders.io/systems/OE/locations");
        var result = await response.Content.ReadAsStringAsync();
        var locations = JObject.Parse(result)["locations"]?.ToObject<List<Location>>() ?? new List<Location>();

        return locations;
    }
}    
