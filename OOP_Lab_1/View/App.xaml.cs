using System.Windows;
using View.Localization;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var provider = XamlLocalizationProvider.Instance;
            provider.EnsureLanguageLoaded();
            // Привязки должны использовать тот же экземпляр, что и код переключения языка
            Resources["Loc"] = provider;
        }
    }
}
