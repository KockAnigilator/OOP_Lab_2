namespace View.ViewModels
{
    /// <summary>
    /// ViewModel для вкладки TwoWayBinding.
    /// Демонстрирует двухстороннюю привязку TextBox, CheckBox и Slider.
    /// </summary>
    public class TwoWayBindingViewModel : BaseViewModel
    {
        private string _name;
        private bool _isEnabled;
        private double _volume;

        /// <summary>
        /// Двухсторонняя привязка к TextBox с UpdateSourceTrigger=PropertyChanged.
        /// Изменения передаются в ViewModel при каждом нажатии клавиши.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Двухсторонняя привязка к CheckBox.
        /// Флаг отражает состояние чекбокса и управляет доступностью других контролов.
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        /// <summary>
        /// Двухсторонняя привязка к Slider.
        /// Значение отображается также в TextBlock и ProgressBar.
        /// </summary>
        public double Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public TwoWayBindingViewModel()
        {
            _name = "Иван Иванов";
            _isEnabled = true;
            _volume = 50;
        }
    }
}

