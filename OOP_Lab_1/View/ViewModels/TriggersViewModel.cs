using System;
using System.Windows.Threading;

namespace View.ViewModels
{
    public class TriggersViewModel : BaseViewModel
    {
        private readonly DispatcherTimer _timer;
        private readonly Random _random = new Random();

        private bool _isAlertsEnabled;
        private int _load;
        private int _temperature;

        public bool IsAlertsEnabled
        {
            get => _isAlertsEnabled;
            set => SetProperty(ref _isAlertsEnabled, value);
        }

        public int Load
        {
            get => _load;
            private set => SetProperty(ref _load, value);
        }

        public int Temperature
        {
            get => _temperature;
            private set => SetProperty(ref _temperature, value);
        }

        public bool IsWorking => Load >= 60;
        public bool IsOverheated => Temperature >= 70;

        public TriggersViewModel()
        {
            IsAlertsEnabled = true;
            Load = 25;
            Temperature = 35;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(900)
            };
            _timer.Tick += (s, e) => UpdateMetrics();
            _timer.Start();
        }

        private void UpdateMetrics()
        {
            Load = _random.Next(10, 101);
            Temperature = 25 + (int)(Load * 0.7) + _random.Next(-5, 6);

            OnPropertyChanged(nameof(IsWorking));
            OnPropertyChanged(nameof(IsOverheated));
        }
    }
}
