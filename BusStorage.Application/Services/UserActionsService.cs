using BusStorage.Application.DTOs;
using BusStorage.Application.Repositories;

namespace BusStorage.Application.Services;

public class UserActionsService
{
    private readonly IUserActionsRepository _userActionsRepository;

    public UserActionsService(IUserActionsRepository userActionsRepository)
    {
        _userActionsRepository = userActionsRepository;
    }

    public async Task<List<ClosestBus>> GetClosestBuses(int busId)
    {
        return await _userActionsRepository.GetClosestSchedule(busId);
    }
}