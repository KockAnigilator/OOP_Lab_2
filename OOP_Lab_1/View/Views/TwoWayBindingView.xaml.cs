using System.Windows.Controls;
using View.ViewModels;

namespace View.Views
{
    /// <summary>
    /// Логика взаимодействия для TwoWayBindingView.xaml
    /// </summary>
    public partial class TwoWayBindingView : UserControl
    {
        public TwoWayBindingView()
        {
            InitializeComponent();
            DataContext = new TwoWayBindingViewModel();
        }
    }
}

