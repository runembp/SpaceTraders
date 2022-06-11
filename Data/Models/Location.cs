namespace SpaceTraders.Data.Models;

public class Location
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool AllowsConstruction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}