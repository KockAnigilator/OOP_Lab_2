using System.ComponentModel;
using System.Globalization;
using LocalizationLib;

namespace View.Localization
{
    /// <summary>
    /// Провайдер локализации на основе внешней библиотеки классов (LocalizationLib).
    /// Строки предоставляются классом LocalizationLib.StringsProvider.
    /// </summary>
    public class ExternalLibLocalizationProvider : INotifyPropertyChanged
    {
        private CultureInfo _currentCulture = new CultureInfo("ru");

        private static ExternalLibLocalizationProvider _instance;
        public static ExternalLibLocalizationProvider Instance => _instance ?? (_instance = new ExternalLibLocalizationProvider());

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Equals(value))
                    return;
                _currentCulture = value;
                OnPropertyChanged(nameof(CurrentCulture));
                OnPropertyChanged(string.Empty);
            }
        }

        private string GetResource(string key) => StringsProvider.GetString(_currentCulture, key);

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

        public string GetString(string key) => StringsProvider.GetString(_currentCulture, key);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
