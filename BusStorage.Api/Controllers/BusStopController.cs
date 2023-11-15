using BusStorage.Api.DTOs.BusStop;
using BusStorage.Application.Services;
using BusStorage.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class BusStopController : ControllerBase
{
    private readonly BusStopService _busStopService;

    public BusStopController(BusStopService busStopService)
    {
        _busStopService = busStopService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBusStops()
    {
        var busStops = await _busStopService.GetAllBusStops();
        return Ok(busStops.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> AddBusStop([FromBody] BusStopCreate busStop)
    {
        await _busStopService.AddBusStop(new BusStop{StopName = busStop.StopName, Latitude = busStop.Latitude, Longitude = busStop.Longitude, LocationDescription = busStop.LocationDescription, CityId = busStop.CityId});
        return Ok();
    }

    [HttpPatch]
    [Route(ApiRoutes.BusStop.IdRoute)]
    public async Task<IActionResult> UpdateBusStop([FromBody] BusStopUpdate busStop, int id)
    {
        var res = await _busStopService
            .UpdateBusStop(new BusStop{StopId = id, StopName = busStop.StopName, Latitude = busStop.Latitude, Longitude = busStop.Longitude, LocationDescription = busStop.LocationDescription, CityId = busStop.CityId});

        return Ok();
    }

    [HttpGet]
    [Route(ApiRoutes.BusStop.IdRoute)]
    public async Task<IActionResult> GetBusStopById(int id)
    {
        var res = await _busStopService.GetBusStopById(id);
        return Ok(res);
    }
}