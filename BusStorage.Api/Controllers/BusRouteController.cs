using BusStorage.Api.DTOs.BusRoute;
using BusStorage.Application.Services;
using BusStorage.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class BusRouteController: ControllerBase
{
    private readonly BusRouteService _routeService;

    public BusRouteController(BusRouteService routeService)
    {
        _routeService = routeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoutes()
    {
        var routes = await _routeService.GetAllBusRoutes();
        return Ok(routes.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> AddRoute([FromBody] BusRouteCreate route)
    {
        await _routeService.AddBusRoute(new BusRoute{RouteName = route.RouteName,
            RouteDescription = route.RouteDescription, StartLocation = route.StartLocation,
            EndLocation = route.EndLocation, Distance = route.Distance});
        return Ok();
    }

    [HttpPatch]
    [Route(ApiRoutes.Route.IdRoute)]
    public async Task<IActionResult> UpdateRoute([FromBody] BusRouteUpdate route, int id)
    {
        var res = await _routeService
            .UpdateBusRoute(new BusRoute{RouteId = id, RouteName = route.RouteName,
                RouteDescription = route.RouteDescription});

        return Ok();
    }

    [HttpGet]
    [Route(ApiRoutes.Route.IdRoute)]
    public async Task<IActionResult> GetRouteById(int id)
    {
        var res = await _routeService.GetBusRouteById(id);
        return Ok(res);
    }
}