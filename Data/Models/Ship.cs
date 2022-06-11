namespace SpaceTraders.Data.Models;

public class Ship
{
    
    public string Type { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int MaxCargo { get; set; }
    public int Plating { get; set; }
    public int Speed { get; set; }
    public int Weapons { get; set; }
    
    // When bought
    public string? Id { get; set; }
    public string? Location { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
    public int? SpaceAvailable { get; set; }

    public List<PurchaseLocation> PurchaseLocations { get; set; } = new();
    public List<InventoryItem> Cargo { get; set; } = new();

    public int GetLowestPrice()
    {
        return PurchaseLocations.Min(x => x.Price);
    }

    public string GetLowestPriceLocation()
    {
        var lowestPrice = PurchaseLocations[0].Price;
        var lowestPriceLocation = PurchaseLocations[0].Location;
        foreach (var location in PurchaseLocations.Where(location => location.Price < lowestPrice))
        {
            lowestPrice = location.Price;
            lowestPriceLocation = location.Location;
        }

        return lowestPriceLocation;
    }
}