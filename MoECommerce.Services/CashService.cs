﻿
using MoECommerce.Core.Interfaces.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoECommerce.Services
{
    public class CashService : ICashService
    {
        private readonly IDatabase _database;

        public CashService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<string?> GetCashResponceAsync(string key)
        {
            var response = await _database.StringGetAsync(key);

            return response.IsNullOrEmpty ? null : response.ToString();
        }

        public async Task SetCashResponceAsync(string key, object response, TimeSpan time)
        {
            var serializedResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            await _database.StringSetAsync(key, serializedResponse, time);
        }
    }
}
