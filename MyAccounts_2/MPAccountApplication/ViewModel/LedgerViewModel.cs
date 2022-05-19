using MPAccountApplication.BaseWindow;
using MPAccountApplication.View;
using MyAccountModels;
using MyAccountsBusiness.BA;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MPAccountApplication.ViewModel
{
    public class LedgerViewModel : AbstractViewEditorModelWindow<LedgerViewWindow, Legder>
    {
        #region Properties 
        private ObservableCollection<BillExpense> _billExpenses;
        private ObservableCollection<Account> _accounts;
        private readonly LedgerBA _ledgerBA;
        private readonly BillExpenseBA _billExpenseBA;
        private readonly AccountBA _accountBA;


        public static readonly DependencyProperty BillExpenseProperty = DependencyProperty.Register(
           "ExpenseType", typeof(BillExpense), typeof(LedgerViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty AccountProperty = DependencyProperty.Register(
  "ExpenseType2", typeof(Account), typeof(LedgerViewModel), new PropertyMetadata(null));

        public Account Account
        {
            get { return (Account)this.GetValue(AccountProperty); }
            set
            {
                this.SetValue(AccountProperty, value);
                this.DataItem.Account = Account;
            
            }
        }

        public BillExpense BillExpense
        {
            get { return (BillExpense)this.GetValue(BillExpenseProperty); }
            set
            {
                this.SetValue(BillExpenseProperty, value);
                this.DataItem.BillExpense = BillExpense;
                this.DataItem.Payment = BillExpense.Payment; 
            }
        }

        public ObservableCollection<BillExpense> BillExpenses
        {
            get { return _billExpenses; }
            set
            {
                _billExpenses = value;
                OnPropertyChanged("BillExpenses");
            }
        }

        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        #endregion




        public LedgerViewModel()
        {
            _ledgerBA = new LedgerBA();
            _accountBA = new AccountBA(); 
            _billExpenseBA = new BillExpenseBA();
            BillExpenses = new ObservableCollection<BillExpense>();
            DataItem = new Legder();
            Account = new Account();
            BillExpense = new BillExpense(); 
            Accounts = new ObservableCollection<Account>(); 

        }



        private async Task GetLedgerItemsAsync()
        {
            //Items = new ObservableCollection<Legder>();
            //var items =  _ledgerBA.GetByAccountId(Account.Id).Result;

            //items.ForEach(x => Items.Add(x)); 

        }

        public async override Task ShowWindowAsync()
        {
            //var items = await _ledgerBA.GetAsync();
            //items.ForEach(x => Items.Add(x)); 
            //var bills = await _billExpenseBA.GetAsync();
            //bills.ForEach(x => BillExpenses.Add(x));

            //var accounts = await _accountBA.GetAsync();
            //accounts.ForEach(x => Accounts.Add(x)); 

            this.Window.DataContext = this;
            this.Window.Show();

          //  Account = Accounts.FirstOrDefault(x => x.PrimaryAccount); 
        }

        protected override void Bindable()
        {
            if (DataItem != null && DataItem.Id > 0)
            {
                BillExpense = BillExpenses.FirstOrDefault(x => x.Id == DataItem.BillExpenseId);
                DataItem.Payment = BillExpense.Payment; 
            }
        }

        protected async override Task Close_Command_Click_Async()
        {
            this.Window.Close();
        }

        protected async override Task Delete_Command_Click_Async()
        {
            var item = await _ledgerBA.GetByIdAsync(DataItem.Id);
            if (item.Id > 0)
            {
                _ledgerBA.Delete(item);
                Items.Remove(DataItem);
            }
        }

        protected async override Task New_Command_Click_Async()
        {
            DataItem = null;
            DataItem = new Legder()
            {
                PaymentDate = DateTime.Now
            };
        }

        protected async override Task Save_Command_Click_Async()
        {
    
            if(BillExpense != null && BillExpense.Id > 0)
            {
                this.DataItem.BillExpenseId = BillExpense.Id;
                this.DataItem.BillExpense = BillExpense;
            }
            if(Account != null && Account.Id > 0)
            {
                this.DataItem.Account = Account;
                this.DataItem.AccountId = Account.Id;
                if (DataItem != null)
                {
                    if (DataItem.Id == 0)
                    {
                        var t = await _ledgerBA.SaveAsync(DataItem, BillExpense);
                        Items.Add(t);
                    }
                    else
                    {
                        var t = await _ledgerBA.SaveAsync(DataItem, BillExpense);
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing Account"); 
            }

          
        }
    }
}
