using System.Windows.Controls;
using View.ViewModels;

namespace View.Views
{
    /// <summary>
    /// Логика взаимодействия для DefaultBindingView.xaml
    /// </summary>
    public partial class DefaultBindingView : UserControl
    {
        public DefaultBindingView()
        {
            InitializeComponent();
            DataContext = new DefaultBindingViewModel();
        }
    }
}

