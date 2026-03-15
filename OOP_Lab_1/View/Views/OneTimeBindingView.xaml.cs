using System.Windows.Controls;
using View.ViewModels;

namespace View.Views
{
    /// <summary>
    /// Логика взаимодействия для OneTimeBindingView.xaml
    /// </summary>
    public partial class OneTimeBindingView : UserControl
    {
        public OneTimeBindingView()
        {
            InitializeComponent();
            DataContext = new OneTimeBindingViewModel();
        }
    }
}

