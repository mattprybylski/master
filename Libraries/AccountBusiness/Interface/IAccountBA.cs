using AccountBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Interface
{
    public interface IAccountBA
    {
        Task<Tuple<Account, string>> InsertAsync(Account account, CancellationToken cancellationToken = default);
        Task<Tuple<Account, string>> UpdateAsync(Account account, CancellationToken cancellationToken = default);
        Task<Tuple<Account, string>> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Account> GetByIdAsync(int id);
        Task<List<Account>> GetAsync();
    }
}
