using BusStorage.Api.DTOs.Schedule;
using BusStorage.Application.Services;
using BusStorage.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class ScheduleController : ControllerBase
{

    private readonly ScheduleService _scheduleService;

    public ScheduleController(ScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSchedules()
    {
        var schedules = await _scheduleService.GetAllSchedules();
        return Ok(schedules.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> AddSchedule([FromBody] ScheduleCreate schedule)
    {
        await _scheduleService.AddSchedule(new Schedule{BusId = schedule.BusId, RouteId = schedule.RouteId, StopId = schedule.StopId, DepartureTime = schedule.DepartureTime, ArrivalTime = schedule.ArrivalTime});
        return Ok();
    }

    [HttpPatch]
    [Route(ApiRoutes.Schedule.IdRoute)]
    public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleUpdate schedule, int id)
    {
        var res = await _scheduleService
            .UpdateSchedule(new Schedule{ScheduleId = id, BusId = schedule.BusId, StopId = schedule.StopId, DepartureTime = schedule.DepartureTime, ArrivalTime = schedule.ArrivalTime});

        return Ok();
    }

    [HttpGet]
    [Route(ApiRoutes.Schedule.IdRoute)]
    public async Task<IActionResult> GetScheduleById(int id)
    {
        var res = await _scheduleService.GetScheduleById(id);
        return Ok(res);
    }
}