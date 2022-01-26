using Pregatit.MonkeyFinder.Core.Interfaces;
using Pregatit.MonkeyFinder.Services.Dto;
using Pregatit.MonkeyFinder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Pregatit.MonkeyFinder.Services.Mappings;

namespace Pregatit.MonkeyFinder.Services
{
    public class MonkeyService : IMonkeyService
    {
        private readonly IMonkeyRepository _monkeyRepo;

        public MonkeyService(IMonkeyRepository monkeyRepo)
        {
            _monkeyRepo = monkeyRepo;
        }

        public Task<bool> CreateMonkeyAsync(MonkeyDto monkey)
        {
            return _monkeyRepo.CreateMonkeyAsync(monkey.FromDto());
        }

        public Task<bool> DeleteMonkeyByIDAsync(int id)
        {
            return _monkeyRepo.DeleteMonkeyByIDAsync(id);
        }

        public async Task<MonkeyDto> GetMonkeyAsyncByID(int id)
        {
            var monkey = await _monkeyRepo.GetMonkeyAsyncByID(id);

            var monkeyDto = monkey.ToDto();

            return monkeyDto;
        }

        public async Task<IEnumerable<MonkeyDto>> GetMonkeysAsync()
        {
            var monkeys = await _monkeyRepo.GetMonkeysAsync();

            var monkeyDtos = monkeys.Select(m => m.ToDto()).ToList();

            return monkeyDtos;
        }

        public Task<bool> UpdateMonkeyByIDAsync(MonkeyDto monkey, int id)
        {
            return _monkeyRepo.UpdateMonkeyByIDAsync(monkey.FromDto(id));
        }
    }
}
