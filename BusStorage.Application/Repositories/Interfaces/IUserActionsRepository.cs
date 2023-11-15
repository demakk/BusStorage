using BusStorage.Application.DTOs;

namespace BusStorage.Application.Repositories;

public interface IUserActionsRepository
{
    public Task<List<ClosestBus>> GetClosestSchedule(int busId);
}