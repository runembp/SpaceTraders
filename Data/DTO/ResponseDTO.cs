namespace SpaceTraders.Data.DTO;

public class ResponseDTO
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}