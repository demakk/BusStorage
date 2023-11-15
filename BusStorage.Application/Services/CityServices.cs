using BusStorage.Application.Repositories;
using BusStorage.Domain.Aggregates;

namespace BusStorage.Application.Services;

public class CityServices
{
    private readonly CityRepository _cityRepository;

    public CityServices(CityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City> AddCity(City city)
    {
        await _cityRepository.Add(city);
        return new City();
    }
    
    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _cityRepository.GetAll();
    }

    public async Task<City> UpdateCity(City city)
    {
        return await _cityRepository.Update(city);
    }

    public async Task<City> GetCityById(int id)
    {
        return await _cityRepository.GetById(id);
    }
}