using MPAccountApplication.BaseWindow;
using MPAccountApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccountApplication.ViewModel
{
    public class MainWindowViewModel  : AbstractViewModelWindow<MainWindow>
    {

  
     //   private ExpenseViewModel _expenseViewModel;
        private BillExpenseViewModel _billExpenseViewModel;
        private AccountViewModel _accountViewModel;
        private LedgerViewModel _ledgerViewModel; 
        #region Commands 
        private RelayComandAsync _expenseTypeCommand;
        private RelayComandAsync _expenseCommand;
        private RelayComandAsync _billExpenseCommand;
        private RelayComandAsync _accountCommand;
        private RelayComandAsync _ledgerCommand;

        public RelayComandAsync AccountCommand
        {
            get { return _accountCommand; }
        }
        public RelayComandAsync ExpenseTypeCommand
        {
            get { return _expenseTypeCommand; }
        }

        public RelayComandAsync ExpenseCommand
        {
            get { return _expenseCommand; }
        }
        public RelayComandAsync LedgerCommand
        {
            get { return _ledgerCommand; }
        }

        public RelayComandAsync BillExpenseCommand
        {
            get { return _billExpenseCommand; }
        }

        public  async Task ExpenseType_Command_Click_Async()
        {
  
        }

        public async Task Expense_Command_Click_Async()
        {
          //  _expenseViewModel = new ExpenseViewModel(); 
           // await _expenseViewModel.ShowWindowAsync(); 
        }

        public async Task BillExpense_Command_Click_Async()
        {
            _billExpenseViewModel = new BillExpenseViewModel();
            await _billExpenseViewModel.ShowWindowAsync();
        }

        public async Task Account_Command_Click_Async()
        {
            _accountViewModel = new AccountViewModel();
            await _accountViewModel.ShowWindowAsync();
        }

        public async Task Ledger_Command_Click_Async()
        {
            _ledgerViewModel = new LedgerViewModel();
            await _ledgerViewModel.ShowWindowAsync();
        }

        #endregion 



        public MainWindowViewModel()
        {
            _expenseTypeCommand = new RelayComandAsync(ExpenseType_Command_Click_Async);
            _expenseCommand = new RelayComandAsync(Expense_Command_Click_Async);
            _billExpenseCommand = new RelayComandAsync(BillExpense_Command_Click_Async);
            _accountCommand = new RelayComandAsync(Account_Command_Click_Async);
            _ledgerCommand = new RelayComandAsync(Ledger_Command_Click_Async); 

            this.Window.DataContext = this;
 
        }

        public async override Task ShowWindowAsync()
        {
            Window.Show(); 
        }
    }
}
