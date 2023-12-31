﻿namespace BusStorage.Domain.Aggregates;

public class Bus
{
    public int BusId { get; set; }
    public string BusNumber { get; set; }
    public string? Model { get; set; }
    public int ManufacturingYear { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }
}