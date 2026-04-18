using System.Windows.Controls;
using View.ViewModels;

namespace View.Views
{
    public partial class TriggersView : UserControl
    {
        public TriggersView()
        {
            InitializeComponent();
            DataContext = new TriggersViewModel();
        }
    }
}
