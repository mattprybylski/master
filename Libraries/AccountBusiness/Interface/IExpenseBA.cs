using AccountBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Interface
{
    public interface IExpenseBA
    {
        Task<Tuple<Expense, string>> InsertAsync(Expense expense, CancellationToken cancellationToken = default);
        Task<Tuple<Expense, string>> UpdateAsync(Expense expense, CancellationToken cancellationToken = default);
        Task<Tuple<Expense, string>> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Expense> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Expense>> GetAsync(CancellationToken cancellationToken = default);
    }
}
