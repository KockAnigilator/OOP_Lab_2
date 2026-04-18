using System.Windows.Controls;
using View.ViewModels;

namespace View.Views
{
    public partial class OneWayBindingView : UserControl
    {
        public OneWayBindingView()
        {
            InitializeComponent();
            DataContext = new OneWayBindingViewModel();
        }
    }
}
