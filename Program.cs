using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorise(options => options.Immediate = true);
builder.Services.AddBootstrapProviders();
builder.Services.AddFontAwesomeIcons();
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["DefaultConnection"]),
    DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["Token"])}
});
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ShipService>();
builder.Services.AddScoped<BankService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<MarketService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();