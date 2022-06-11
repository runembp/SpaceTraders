namespace SpaceTraders.Data.Services;

public class AccountService : BaseService
{
    public AccountService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<User> GetUser()
    {
        var response = await HttpClient.GetAsync($"/my/account");
        var result = await response.Content.ReadAsStringAsync();
        return JObject.Parse(result)["user"]?.ToObject<User>() ?? new User();
    }

    public async Task<List<Ship>> GetOwnedShips()
    {
        var response = await HttpClient.GetAsync("my/ships");
        var result = await response.Content.ReadAsStringAsync();
        return JObject.Parse(result)["ships"]?.ToObject<List<Ship>>() ?? new List<Ship>();
    }

    public async Task<Ship> GetOwnedShip(string? shipId)
    {
        var response = await HttpClient.GetAsync($"my/ships?shipId={shipId}");
        var result = await response.Content.ReadAsStringAsync();
        return JObject.Parse(result)["ships"]?.FirstOrDefault()?.ToObject<Ship?>() ?? new Ship();
    }
    
    public async Task<ResponseDTO> BuyFuelForShip(BuyGoodDTO order)
    {
        var response = new ResponseDTO();

        var httpResponse = await HttpClient.PostAsJsonAsync("/my/purchase-orders", order);
        if (!httpResponse.IsSuccessStatusCode)
        {
            response.Error = await httpResponse.ParseHttpContentErrorMessage();
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}