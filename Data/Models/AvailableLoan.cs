namespace SpaceTraders.Data.Models;

public class AvailableLoan
{
    public string Type { get; set; } = string.Empty;
    public double Amount { get; set; }
    public int Rate { get; set; }
    public int TermInDays { get; set; }
    public bool CollateralRequired { get; set; }
}