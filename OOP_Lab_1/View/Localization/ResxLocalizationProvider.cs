using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace View.Localization
{
    /// <summary>
    /// Провайдер локализации на основе файлов ресурсов (RESX).
    /// Поддерживает динамическое переключение языка во время работы приложения.
    /// </summary>
    public class ResxLocalizationProvider : INotifyPropertyChanged
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("View.Properties.Strings", typeof(ResxLocalizationProvider).Assembly);

        private CultureInfo _currentCulture = new CultureInfo("ru");

        private static ResxLocalizationProvider _instance;
        public static ResxLocalizationProvider Instance => _instance ?? (_instance = new ResxLocalizationProvider());

        /// <summary>
        /// Текущая культура интерфейса (ru / en).
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Equals(value))
                    return;
                _currentCulture = value;
                OnPropertyChanged(nameof(CurrentCulture));
                OnPropertyChanged(string.Empty); // обновить все привязанные строки
            }
        }

        public string WindowTitle => GetString("WindowTitle");
        public string Language => GetString("Language");
        public string Tab_DefaultBinding => GetString("Tab_DefaultBinding");
        public string Tab_TwoWayBinding => GetString("Tab_TwoWayBinding");
        public string Tab_OneTimeBinding => GetString("Tab_OneTimeBinding");
        public string Tab_OneWayBinding => GetString("Tab_OneWayBinding");
        public string Tab_Triggers => GetString("Tab_Triggers");
        public string DefaultBinding_Header => GetString("DefaultBinding_Header");
        public string DefaultBinding_Description => GetString("DefaultBinding_Description");
        public string DefaultBinding_WindowBinding => GetString("DefaultBinding_WindowBinding");
        public string DefaultBinding_ViewModelBinding => GetString("DefaultBinding_ViewModelBinding");
        public string DefaultBinding_CurrentWindowValue => GetString("DefaultBinding_CurrentWindowValue");
        public string DefaultBinding_CurrentViewModelValue => GetString("DefaultBinding_CurrentViewModelValue");
        public string DefaultBinding_LastUpdated => GetString("DefaultBinding_LastUpdated");
        public string Message_DataSaved => GetString("Message_DataSaved");
        public string Button_ShowMessage => GetString("Button_ShowMessage");
        public string Triggers_Placeholder => GetString("Triggers_Placeholder");
        public string OneWay_Placeholder => GetString("OneWay_Placeholder");

        public string GetString(string key)
        {
            return ResourceManager.GetString(key, _currentCulture) ?? key;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
