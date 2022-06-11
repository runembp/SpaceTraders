namespace SpaceTraders.Data.Services;

public class BankService : BaseService
{
    public BankService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<AvailableLoan>> AvailableLoans()
    {
        var response = await HttpClient.GetAsync($"/types/loans");
        var result = await response.Content.ReadAsStringAsync();
        return JObject.Parse(result)["loans"]?.ToObject<List<AvailableLoan>>() ?? new List<AvailableLoan>();
    }

    public async Task<ResponseDTO> AddLoan(string loanType)
    {
        var response = new ResponseDTO();

        var body = new Dictionary<string, string> {{"type", loanType}};
        
        var result = await HttpClient.PostAsJsonAsync("/my/loans", body);

        if (!result.IsSuccessStatusCode)
        {
            response.Error = await result.ParseHttpContentErrorMessage();
            return response;
        } 

        response.Succeeded = true;
        return response;
    }
}