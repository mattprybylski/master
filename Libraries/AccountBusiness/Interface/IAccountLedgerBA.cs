using AccountBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Interface
{
    public interface IAccountLedgerBA
    {
        Task<Tuple<AccountLedger, string>> InsertAsync(AccountLedger accountLedger, CancellationToken cancellationToken = default);
        Task<Tuple<AccountLedger, string>> UpdateAsync(AccountLedger accountLedger, CancellationToken cancellationToken = default);
        Task<Tuple<AccountLedger, string>> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<AccountLedger> GetByIdAsync(int id);
        Task<List<AccountLedger>> GetAsync();
    }
}
