namespace SpaceTraders.Data.Models;

public class User
{
    public string Username { get; set; } = string.Empty;
    public double Credits { get; set; }
    public int ShipCount { get; set; }
    public int StructureCount { get; set; }

    public string JoinedAt { get; set; } = string.Empty;
}