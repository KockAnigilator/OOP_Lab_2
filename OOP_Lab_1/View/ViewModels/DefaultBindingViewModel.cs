using System;

namespace View.ViewModels
{
    /// <summary>
    /// ViewModel для вкладки DefaultBinding.
    /// Показывает работу привязки по умолчанию для TextBox (UpdateSourceTrigger=LostFocus).
    /// </summary>
    public class DefaultBindingViewModel : BaseViewModel
    {
        private string _viewModelText;
        private DateTime _lastUpdated;

        /// <summary>
        /// Свойство, к которому привязан TextBox через ViewModel.
        /// Источник обновляется только при потере фокуса (значение по умолчанию).
        /// </summary>
        public string ViewModelText
        {
            get => _viewModelText;
            set
            {
                if (SetProperty(ref _viewModelText, value))
                {
                    LastUpdated = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Время последнего обновления ViewModelText.
        /// </summary>
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            private set => SetProperty(ref _lastUpdated, value);
        }

        public DefaultBindingViewModel()
        {
            _viewModelText = "Начальное значение из ViewModel";
            _lastUpdated = DateTime.Now;
        }
    }
}

