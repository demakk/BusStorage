using BusStorage.Api.DTOs.City;
using BusStorage.Application.Services;
using BusStorage.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace BusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class CityController : ControllerBase
{
    private readonly CityServices _cityService;

    public CityController(CityServices cityService)
    {
        _cityService = cityService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        var cities = await _cityService.GetAllCities();
        return Ok(cities.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> AddCity([FromBody] CityCreate city)
    {
        await _cityService.AddCity(new City{CityName = city.CityName, EstablishedYear = city.EstablishedYear, CityId = 0});
        return Ok();
    }

    [HttpPatch]
    [Route(ApiRoutes.City.IdRoute)]
    public async Task<IActionResult> UpdateCity([FromBody] CityUpdate city, int id)
    {
        var res = await _cityService
            .UpdateCity(new City{CityId = id, CityName = city.CityName, EstablishedYear = city.EstablishedYear});

        return Ok();
    }

    [HttpGet]
    [Route(ApiRoutes.City.IdRoute)]
    public async Task<IActionResult> GetCityById(int id)
    {
        var res = await _cityService.GetCityById(id);
        return Ok(res);
    }
}