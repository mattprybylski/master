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
    /// Interaction logic for StateProvinceViewWindow.xaml
    /// </summary>
    public partial class StateProvinceViewWindow : Window
    {
        public StateProvinceViewWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
