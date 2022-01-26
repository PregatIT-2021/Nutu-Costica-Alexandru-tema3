using Pregatit.MonkeyFinder.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregatit.MonkeyFinder.Services.Interfaces
{
    public interface IMonkeyService
    {
        Task<IEnumerable<MonkeyDto>> GetMonkeysAsync();

        Task<MonkeyDto> GetMonkeyAsyncByID(int id);

        // create monkey
        Task<bool> CreateMonkeyAsync(MonkeyDto monkey);

        // update monkey
        Task<bool> UpdateMonkeyByIDAsync(MonkeyDto moonkey, int id);

        // delete monkey
        Task<bool> DeleteMonkeyByIDAsync(int id);
    }
}
