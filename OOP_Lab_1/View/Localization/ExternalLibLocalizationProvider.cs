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
        public string Language_Russian => GetResource("Language_Russian");
        public string Language_English => GetResource("Language_English");
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
        public string DefaultBinding_Tooltip_Window => GetResource("DefaultBinding_Tooltip_Window");
        public string DefaultBinding_Tooltip_ViewModel => GetResource("DefaultBinding_Tooltip_ViewModel");
        public string DefaultBinding_Note => GetResource("DefaultBinding_Note");
        public string Message_DataSaved => GetResource("Message_DataSaved");
        public string Button_ShowMessage => GetResource("Button_ShowMessage");
        public string Triggers_Placeholder => GetResource("Triggers_Placeholder");
        public string OneWay_Placeholder => GetResource("OneWay_Placeholder");
        public string OneTime_Title => GetResource("OneTime_Title");
        public string OneTime_Description => GetResource("OneTime_Description");
        public string OneTime_Compare => GetResource("OneTime_Compare");
        public string OneTime_Start => GetResource("OneTime_Start");
        public string OneTime_Current => GetResource("OneTime_Current");
        public string OneTime_StartFormat => GetResource("OneTime_StartFormat");
        public string OneTime_CurrentFormat => GetResource("OneTime_CurrentFormat");
        public string OneTime_Note => GetResource("OneTime_Note");
        public string TwoWay_Title => GetResource("TwoWay_Title");
        public string TwoWay_Description => GetResource("TwoWay_Description");
        public string TwoWay_WindowBinding => GetResource("TwoWay_WindowBinding");
        public string TwoWay_WindowTooltip => GetResource("TwoWay_WindowTooltip");
        public string TwoWay_CurrentWindow => GetResource("TwoWay_CurrentWindow");
        public string TwoWay_ViewModelSection => GetResource("TwoWay_ViewModelSection");
        public string TwoWay_NameCaption => GetResource("TwoWay_NameCaption");
        public string TwoWay_NameCurrentFormat => GetResource("TwoWay_NameCurrentFormat");
        public string TwoWay_IsEnabledCaption => GetResource("TwoWay_IsEnabledCaption");
        public string TwoWay_VolumeCaption => GetResource("TwoWay_VolumeCaption");
        public string TwoWay_VolumeCurrentFormat => GetResource("TwoWay_VolumeCurrentFormat");
        public string TwoWay_Note => GetResource("TwoWay_Note");
        public string OneWay_Title => GetResource("OneWay_Title");
        public string OneWay_Description => GetResource("OneWay_Description");
        public string OneWay_SourceValue => GetResource("OneWay_SourceValue");
        public string OneWay_BoundValue => GetResource("OneWay_BoundValue");
        public string OneWay_UserInput => GetResource("OneWay_UserInput");
        public string OneWay_UserInputHint => GetResource("OneWay_UserInputHint");
        public string OneWay_Note => GetResource("OneWay_Note");
        public string Triggers_Title => GetResource("Triggers_Title");
        public string Triggers_Description => GetResource("Triggers_Description");
        public string Triggers_EnableAlerts => GetResource("Triggers_EnableAlerts");
        public string Triggers_Load => GetResource("Triggers_Load");
        public string Triggers_ProgressCaption => GetResource("Triggers_ProgressCaption");
        public string Triggers_StatusCaption => GetResource("Triggers_StatusCaption");
        public string Triggers_TempCaption => GetResource("Triggers_TempCaption");
        public string Triggers_Ready => GetResource("Triggers_Ready");
        public string Triggers_Working => GetResource("Triggers_Working");
        public string Triggers_Overheat => GetResource("Triggers_Overheat");
        public string Triggers_Warning => GetResource("Triggers_Warning");

        public string GetString(string key) => StringsProvider.GetString(_currentCulture, key);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
