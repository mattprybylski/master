using MPAccountApplication.BaseWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MPAccountApplication.Common
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        public SearchUserControl()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (sender as TextBox);

            var dataContextWindow = textBox.DataContext as IViewEditorBase;

            dataContextWindow.SearchAsync(textBox.Text);



        }
    }
}
