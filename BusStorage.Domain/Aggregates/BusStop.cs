namespace BusStorage.Domain.Aggregates;

public class BusStop
{
    public int Id { get; set; }
    public string StopName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? LocationDescription { get; set; }
    public int CityId { get; set; }
}