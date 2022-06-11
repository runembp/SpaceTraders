namespace SpaceTraders.Data.Services;

public class ShipService : BaseService
{
    public ShipService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Ship>> GetShipCatalogue()
    {
        var response = await HttpClient.GetAsync("/types/ships");
        var result = await response.Content.ReadAsStringAsync();
        return JObject.Parse(result)["ships"]?.ToObject<List<Ship>>() ?? new List<Ship>();
    }

    public async Task<List<Ship>> GetAvailableShipsForSystem(string currentSystemSymbol)
    {
        var response = await HttpClient.GetAsync($"/systems/{currentSystemSymbol}/ship-listings");
        var result = await response.Content.ReadAsStringAsync();
        var shipList = JObject.Parse(result)["shipListings"]?.ToObject<List<Ship>>() ?? new List<Ship>();
        shipList = shipList.OrderBy(x => x.GetLowestPrice()).ToList();

        return shipList;
    }

    public async Task<ResponseDTO> BuyShip(BuyShipDTO shipDTO)
    {
        var response = new ResponseDTO();
        
        var httpResponse = await HttpClient.PostAsJsonAsync("/my/ships", shipDTO);
        if (!httpResponse.IsSuccessStatusCode)
        {
            response.Error = await httpResponse.ParseHttpContentErrorMessage();
            return response;
        }

        response.Succeeded = true;
        return response;
    }

    
}