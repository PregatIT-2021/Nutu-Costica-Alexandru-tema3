using Pregatit.MonkeyFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregatit.MonkeyFinder.Core.Interfaces
{
    public interface IMonkeyRepository
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();

        Task<Monkey> GetMonkeyAsyncByID(int id);

        // create monkey
        Task<bool> CreateMonkeyAsync(Monkey monkey);

        // update monkey
        Task<bool> UpdateMonkeyByIDAsync(Monkey monkey);

        // delete monkey
        Task<bool> DeleteMonkeyByIDAsync(int id);
    }
}
