using System;
using System.Windows.Threading;

namespace View.ViewModels
{
    /// <summary>
    /// ViewModel для вкладки OneTimeBinding.
    /// Показывает, что OneTime-привязка читает значение только один раз при загрузке.
    /// </summary>
    public class OneTimeBindingViewModel : BaseViewModel
    {
        private readonly DispatcherTimer _timer;
        private DateTime _startTime;
        private DateTime _currentTime;

        /// <summary>
        /// Дата и время запуска приложения (источник для OneTime-привязки).
        /// </summary>
        public DateTime StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        /// <summary>
        /// Текущее время, которое постоянно обновляется — для сравнения с OneTime.
        /// </summary>
        public DateTime CurrentTime
        {
            get => _currentTime;
            private set => SetProperty(ref _currentTime, value);
        }

        public OneTimeBindingViewModel()
        {
            StartTime = DateTime.Now;
            CurrentTime = DateTime.Now;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) => CurrentTime = DateTime.Now;
            _timer.Start();
        }
    }
}

