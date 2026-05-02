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

            // Устанавливаем DataContext окна на провайдер локализации
            // Это позволит привязкам в окне работать без StaticResource
            DataContext = ExternalLibLocalizationProvider.Instance;

            // Синхронизируем ComboBox с текущей культурой
            SyncLanguageComboBox();
        }

        private void SyncLanguageComboBox()
        {
            var provider = ExternalLibLocalizationProvider.Instance;
            var cultureName = provider.CurrentCulture.Name.StartsWith("en") ? "en" : "ru";

            foreach (ComboBoxItem item in LanguageComboBox.Items)
            {
                if (item.Tag is string tag && tag == cultureName)
                {
                    LanguageComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem item && item.Tag is string tag)
            {
                ExternalLibLocalizationProvider.Instance.CurrentCulture = new CultureInfo(tag);
            }
        }
    }
}