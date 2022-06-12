namespace SpaceTraders.Data.Services;

public class MarketService : BaseService
{
    public MarketService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<Good>> GetAvailableGoods()
    {
        var response = await HttpClient.GetAsync("/types/goods");
        var content = await response.Content.ReadAsStringAsync();
        var goods = JObject.Parse(content)["goods"]?.ToObject<List<Good>>() ?? new List<Good>();

        return goods;
    }
}