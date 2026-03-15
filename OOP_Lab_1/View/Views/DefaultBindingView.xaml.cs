using System.Windows;
using System.Windows.Controls;
using View.Localization;
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

        private void ShowMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = ExternalLibLocalizationProvider.Instance.GetString("Message_DataSaved");
            MessageBox.Show(message);
        }
    }
}

