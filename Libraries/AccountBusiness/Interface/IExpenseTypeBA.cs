using AccountBusiness.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Interface
{
    public interface IExpenseTypeBA
    {
        Task<Tuple<ExpenseType, string>> InsertAsync(ExpenseType expenseType, CancellationToken cancellationToken = default);
        Task<Tuple<ExpenseType, string>> UpdateAsync(ExpenseType expenseType, CancellationToken cancellationToken = default);
        Task<Tuple<ExpenseType, string>> DeleteAsync(ExpenseType expenseType, CancellationToken cancellationToken = default);
        Task<ExpenseType> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<ExpenseType>> GetAsync(CancellationToken cancellationToken = default);
        Task<ObservableCollection<ExpenseType>> GetObservableCollection(CancellationToken cancellation = default);
    }
}
