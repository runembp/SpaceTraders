namespace SpaceTraders.Data.HelperClasses;

public static class HelperClass
{
    public static async Task<string?> ParseHttpContentErrorMessage(this HttpResponseMessage message)
    {
        return JObject.Parse(await message.Content.ReadAsStringAsync())["error"]?["message"]?.ToString();
    }
}