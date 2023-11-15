using BusStorage.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class UserController : ControllerBase
{
    private readonly UserActionsService _userService;

    public UserController(UserActionsService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route(ApiRoutes.User.StopIdRoute)]
    public async Task<IActionResult> GetClosestBusesByBusStopId(int stopId)
    {
        var res = await _userService.GetClosestBuses(stopId);
        return Ok(res);
    }
}