﻿using System.Data;
using BusStorage.Application.DTOs;
using BusStorage.Domain.Aggregates;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BusStorage.Application.Repositories;

public class UserActionsRepository : IUserActionsRepository
{

    private readonly string _connectionString;

    public UserActionsRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public async Task<List<ClosestBus>> GetClosestSchedule(int busId)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var obj = new { StopId = busId };
        
        var res =  await connection.QueryAsync<ClosestBus>(
            "[dbo].[FindBusesAtStopInNextHour]",
            obj,
            commandType: CommandType.StoredProcedure
        );

        return res.ToList();
    }
    
}