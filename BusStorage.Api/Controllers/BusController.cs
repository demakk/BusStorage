using BusStorage.Api.DTOs.Bus;
using BusStorage.Application.Services;
using BusStorage.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class BusController : ControllerBase
{
        private readonly BusService _busService;

        public BusController(BusService busService)
        {
                _busService = busService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllBuses()
        {
                var buses = await _busService.GetAllBuses();
                return Ok(buses.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] BusCreate bus)
        {
                await _busService.AddBus(new Bus{BusId = 0, BusNumber = bus.BusNumber, Model = bus.Model,
                        ManufacturingYear = bus.ManufacturingYear, Capacity = bus.Capacity,
                        Status = bus.Status});
                return Ok();
        }

        [HttpPatch]
        [Route(ApiRoutes.Bus.IdRoute)]
        public async Task<IActionResult> UpdateBus([FromBody] BusUpdate bus, int id)
        {
                var res = await _busService
                        .UpdateBus(new Bus { BusId = id, BusNumber = bus.BusNumber, Model = bus.Model,
                                ManufacturingYear = bus.ManufacturingYear, Capacity = bus.Capacity,
                                Status = bus.Status });

                return Ok();
        }
        
        [HttpPatch]
        [Route(ApiRoutes.Bus.NumberRoute)]
        public async Task<IActionResult> UpdateBusByNumber([FromBody] BusUpdateByNumber bus, string number)
        {
                var res = await _busService
                        .UpdateBusByNumber(new Bus {BusId = 0, BusNumber = number, Model = bus.Model,
                                ManufacturingYear = bus.ManufacturingYear, Capacity = bus.Capacity,
                                Status = bus.Status });

                return Ok();
        }

        [HttpGet]
        [Route(ApiRoutes.Bus.IdRoute)]
        public async Task<IActionResult> GetBusById(int id)
        {
                var res = await _busService.GetBusById(id);
                return Ok(res);
        }
        
        [HttpGet]
        [Route(ApiRoutes.Bus.NumberRoute)]
        public async Task<IActionResult> GetBusByNumber([FromRoute]string number)
        {
                var res = await _busService.GetBusByNumber(number);
                return Ok(res);
        }
        
        
}