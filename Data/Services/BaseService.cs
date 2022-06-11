namespace SpaceTraders.Data.Services;

public abstract class BaseService
{
    protected HttpClient HttpClient { get; }
    
    protected BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
}