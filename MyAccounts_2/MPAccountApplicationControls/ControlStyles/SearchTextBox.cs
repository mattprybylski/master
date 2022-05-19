using Microsoft.VisualStudio.PlatformUI;
using MPAccountApplicationControls.Command;
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

namespace MPAccountApplicationControls.ControlStyles
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MPAccountApplicationControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MPAccountApplicationControls;assembly=MPAccountApplicationControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SearchTextBox/>
    ///
    /// </summary>
    public class SearchTextBox : TextBox
    {
        private TextBox PART_SearchTermTextBox;

        private RelayCommand relayCommand; 
        public RelayCommand RelayCommand
        {
            get { return relayCommand;  }
        }

        public static DependencyProperty ReloadCommandProperty
           = DependencyProperty.Register(
               "ReloadCommand",
               typeof(ICommand),
               typeof(SearchTextBox));

        public static DependencyProperty SaveCommandProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(SearchTextBox));

        public ICommand ReloadCommand
        {
            get
            {
                return (ICommand)GetValue(ReloadCommandProperty);
            }

            set
            {
                SetValue(ReloadCommandProperty, value);
            }
        }

        public SearchTextBox()
        {
            TextChanged += SearchTextBox_TextChanged;
            
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
 
        }

        private void PART_SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
