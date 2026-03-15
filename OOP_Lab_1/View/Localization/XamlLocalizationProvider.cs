using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace View.Localization
{
    /// <summary>
    /// Провайдер локализации на основе словарей ресурсов XAML (ResourceDictionary).
    /// Строки хранятся в Strings.ru.xaml и Strings.en.xaml, переключение — замена MergedDictionary.
    /// </summary>
    public class XamlLocalizationProvider : INotifyPropertyChanged
    {
        private CultureInfo _currentCulture = new CultureInfo("ru");
        private ResourceDictionary _currentLanguageDictionary;

        private static XamlLocalizationProvider _instance;
        public static XamlLocalizationProvider Instance => _instance ?? (_instance = new XamlLocalizationProvider());

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Equals(value))
                    return;
                _currentCulture = value;
                LoadLanguageDictionary();
                OnPropertyChanged(nameof(CurrentCulture));
                OnPropertyChanged(string.Empty);
            }
        }

        private void LoadLanguageDictionary()
        {
            if (Application.Current?.Resources?.MergedDictionaries == null)
                return;

            if (_currentLanguageDictionary != null)
                Application.Current.Resources.MergedDictionaries.Remove(_currentLanguageDictionary);

            var uri = _currentCulture.Name.StartsWith("en")
                ? new System.Uri("pack://application:,,,/View;component/Localization/Strings.en.xaml", System.UriKind.Absolute)
                : new System.Uri("pack://application:,,,/View;component/Localization/Strings.ru.xaml", System.UriKind.Absolute);

            _currentLanguageDictionary = new ResourceDictionary { Source = uri };
            Application.Current.Resources.MergedDictionaries.Add(_currentLanguageDictionary);
        }

        public void EnsureLanguageLoaded()
        {
            if (_currentLanguageDictionary == null)
                LoadLanguageDictionary();
        }

        private string GetResource(string key)
        {
            if (Application.Current?.Resources == null)
                return key;
            var value = Application.Current.Resources[key];
            return value as string ?? key;
        }

        public string GetString(string key) => GetResource(key);

        public string WindowTitle => GetResource("WindowTitle");
        public string Language => GetResource("Language");
        public string Tab_DefaultBinding => GetResource("Tab_DefaultBinding");
        public string Tab_TwoWayBinding => GetResource("Tab_TwoWayBinding");
        public string Tab_OneTimeBinding => GetResource("Tab_OneTimeBinding");
        public string Tab_OneWayBinding => GetResource("Tab_OneWayBinding");
        public string Tab_Triggers => GetResource("Tab_Triggers");
        public string DefaultBinding_Header => GetResource("DefaultBinding_Header");
        public string DefaultBinding_Description => GetResource("DefaultBinding_Description");
        public string DefaultBinding_WindowBinding => GetResource("DefaultBinding_WindowBinding");
        public string DefaultBinding_ViewModelBinding => GetResource("DefaultBinding_ViewModelBinding");
        public string DefaultBinding_CurrentWindowValue => GetResource("DefaultBinding_CurrentWindowValue");
        public string DefaultBinding_CurrentViewModelValue => GetResource("DefaultBinding_CurrentViewModelValue");
        public string DefaultBinding_LastUpdated => GetResource("DefaultBinding_LastUpdated");
        public string Message_DataSaved => GetResource("Message_DataSaved");
        public string Button_ShowMessage => GetResource("Button_ShowMessage");
        public string Triggers_Placeholder => GetResource("Triggers_Placeholder");
        public string OneWay_Placeholder => GetResource("OneWay_Placeholder");

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
