using AccountBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Interface
{
    public interface IExpenseBalance
    {
        Task<Tuple<ExpenseBalance, string>> InsertAsync(ExpenseBalance expenseBalance, CancellationToken cancellationToken = default);
        Task<Tuple<ExpenseBalance, string>> UpdateAsync(ExpenseBalance expenexpenseBalanceseType, CancellationToken cancellationToken = default);
        Task<Tuple<ExpenseBalance, string>> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<ExpenseBalance> GetByIdAsync(int id);
        Task<List<ExpenseBalance>> GetAsync();
    }
}
