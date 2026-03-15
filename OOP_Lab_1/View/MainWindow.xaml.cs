using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using View.Localization;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Свойство окна, к которому выполняется прямая привязка
        /// на вкладке DefaultBinding (для сравнения с привязкой к ViewModel).
        /// </summary>
        public string TextFromWindow { get; set; } = "Начальное значение из окна";

        public MainWindow()
        {
            InitializeComponent();
            var provider = ResxLocalizationProvider.Instance;
            if (provider.CurrentCulture.Name.StartsWith("en"))
                LanguageComboBox.SelectedIndex = 1;
            else
                LanguageComboBox.SelectedIndex = 0;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem item && item.Tag is string tag)
            {
                ResxLocalizationProvider.Instance.CurrentCulture = new CultureInfo(tag);
            }
        }
    }
}
