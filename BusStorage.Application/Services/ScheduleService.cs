using BusStorage.Application.Repositories;
using BusStorage.Domain.Aggregates;

namespace BusStorage.Application.Services;

public class ScheduleService
{
    private readonly ScheduleRepository _scheduleRepository;

    public ScheduleService(ScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task<Schedule> AddSchedule(Schedule schedule)
    {
        await _scheduleRepository.Add(schedule);
        return new Schedule();
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedules()
    {
        return await _scheduleRepository.GetAll();
    }

    public async Task<Schedule> UpdateSchedule(Schedule schedule)
    {
        return await _scheduleRepository.Update(schedule);
    }

    public async Task<Schedule> GetScheduleById(int id)
    {
        return await _scheduleRepository.GetById(id);
    }
}