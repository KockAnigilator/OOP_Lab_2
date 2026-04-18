using System;
using System.Windows.Threading;

namespace View.ViewModels
{
    public class OneWayBindingViewModel : BaseViewModel
    {
        private readonly DispatcherTimer _timer;
        private string _sourceText;

        public string SourceText
        {
            get => _sourceText;
            private set => SetProperty(ref _sourceText, value);
        }

        public OneWayBindingViewModel()
        {
            SourceText = DateTime.Now.ToString("T");

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            _timer.Tick += (s, e) =>
            {
                SourceText = DateTime.Now.ToString("T");
            };

            _timer.Start();
        }
    }
}
