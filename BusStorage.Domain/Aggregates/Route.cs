namespace BusStorage.Domain.Aggregates;

public class Route
{
    public int Id { get; set; }
    public string RouteName { get; set; }
    public string? RouteDescription { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public decimal? Distance { get; set; }
    
    
}