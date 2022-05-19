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
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {

        public string Search
        {
            get { return (string)this.GetValue(SearchProperty); }
            set
            {

                this.SetValue(SearchProperty, value);
                RaiseTapEvent(); 
            }

        }
        public static readonly DependencyProperty SearchProperty = DependencyProperty.Register(
          "Search", typeof(string), typeof(SearchUserControl), new PropertyMetadata(string.Empty));

        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
      "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchUserControl));


        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(SearchUserControl.TapEvent);
            RaiseEvent(newEventArgs);
        }



        public SearchUserControl()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var test = sender as TextBox;
            RaiseTapEvent();

        }
    }
}
