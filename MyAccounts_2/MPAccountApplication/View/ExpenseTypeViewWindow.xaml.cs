using MPAccountApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MPAccountApplication.View
{
    /// <summary>
    /// Interaction logic for ExpenseTypeViewWindow.xaml
    /// </summary>
    public partial class ExpenseTypeViewWindow : Window
    {
        public ExpenseTypeViewWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
            //this.Visibility = Visibility.Hidden;
 
            //var dataContext = (BillExpenseTypeViewModel)this.DataContext;
            //dataContext.Items = null; 

            
            
        }
    }
}
