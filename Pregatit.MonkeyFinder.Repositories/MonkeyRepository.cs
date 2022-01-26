using Pregatit.MonkeyFinder.Core.Entities;
using Pregatit.MonkeyFinder.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Pregatit.MonkeyFinder.Infrastructure.DataAccess;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Pregatit.MonkeyFinder.Repositories
{
    public class MonkeyRepository : IMonkeyRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<MonkeyRepository> _logger;

        public MonkeyRepository(IDbConnectionFactory connectionFactory, ILogger<MonkeyRepository> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public async Task<bool> CreateMonkeyAsync(Monkey monkey)
        {
            try
            {
                await _connectionFactory.GetConnection().InsertAsync(monkey);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteMonkeyByIDAsync(int id)
        {
            try
            {
                await _connectionFactory.GetConnection().DeleteAsync(new Monkey { Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return false;
            }

            return true;
        }

        public async Task<Monkey> GetMonkeyAsyncByID(int id)
        {
            return await _connectionFactory.GetConnection().GetAsync<Monkey>(id);
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            return await _connectionFactory.GetConnection().GetAllAsync<Monkey>();
        }

        public async Task<bool> UpdateMonkeyByIDAsync(Monkey monkey)
        {
            try
            {
                await _connectionFactory.GetConnection().UpdateAsync(monkey);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return false;
            }

            return true;
        }
    }
}
