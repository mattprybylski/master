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

namespace MPAccountAble.VMControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MPAccountAble.VMControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MPAccountAble.VMControls;assembly=MPAccountAble.VMControls"
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
    public class SearchTextBox : Control
    {
        private TextBox PART_SearchTermTextBox; 

        public static readonly DependencyProperty SearchLableProperty =
            DependencyProperty.Register("SearchLable", typeof(string),
            typeof(SearchTextBox),
             new PropertyMetadata("Search"));

        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
    "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchTextBox));

        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }


        public string SearchLable
        {
            get
            {
                return (string)GetValue(SearchLableProperty);
            }
            set
            {
                SetValue(SearchLableProperty, value);
            }
        }

 
        public SearchTextBox()
        {
            SearchLable = "Search...";
        }

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
            
        }

        public override void OnApplyTemplate()
        { 
            base.OnApplyTemplate();

            PART_SearchTermTextBox = GetTemplateChild("PART_SearchTermTextBox") as TextBox;
            PART_SearchTermTextBox.TextChanged += PART_SearchTermTextBox_TextChanged;
        }

        void RaiseTapEvent()
        {
         
        }


        private void PART_SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            RoutedEventArgs newEventArgs = new RoutedEventArgs(SearchTextBox.TapEvent);
            RaiseEvent(newEventArgs);

            //RaiseEvent(e); 

        }
    }
}
