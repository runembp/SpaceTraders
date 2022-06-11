namespace SpaceTraders.Data.Models;

public class Loan
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public double RepaymentAmount { get; set; }
    public string Due { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}