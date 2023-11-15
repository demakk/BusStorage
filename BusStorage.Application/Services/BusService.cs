using BusStorage.Application.Repositories;
using BusStorage.Domain.Aggregates;

namespace BusStorage.Application.Services;

public class BusService
{
    private readonly BusRepository _busRepository;

    public BusService(BusRepository busRepository)
    {
        _busRepository = busRepository;
    }

    public async Task<Bus> AddBus(Bus bus)
    {
        await _busRepository.Add(bus);
        return new Bus();
    }
    
    public async Task<IEnumerable<Bus>> GetAllBuses()
    {
        return await _busRepository.GetAll();
    }

    public async Task<Bus> UpdateBus(Bus bus)
    {
        return await _busRepository.Update(bus);
    }
    
    public async Task<Bus> UpdateBusByNumber(Bus bus)
    {
        return await _busRepository.UpdateByNumber(bus);
    }

    public async Task<Bus> GetBusById(int id)
    {
        return await _busRepository.GetById(id);
    }
    
    public async Task<Bus> GetBusByNumber(string number)
    {
        return await _busRepository.GetByNumber(number);
    }
}