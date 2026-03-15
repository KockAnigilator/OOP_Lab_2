using System;
using System.Collections.Generic;
using System.Globalization;

namespace LocalizationLib
{
    /// <summary>
    /// Внешняя библиотека локализации. Предоставляет строки для русского и английского языков.
    /// </summary>
    public static class StringsProvider
    {
        private static readonly Dictionary<string, string> Ru = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["WindowTitle"] = "Демо привязки MVVM",
            ["Language"] = "Язык",
            ["Tab_DefaultBinding"] = "Привязка по умолчанию",
            ["Tab_TwoWayBinding"] = "Двухсторонняя привязка",
            ["Tab_OneTimeBinding"] = "Одноразовая привязка",
            ["Tab_OneWayBinding"] = "Односторонняя привязка",
            ["Tab_Triggers"] = "Триггеры",
            ["DefaultBinding_Header"] = "DefaultBinding (TextBox, UpdateSourceTrigger по умолчанию — LostFocus)",
            ["DefaultBinding_Description"] = "Сравнение: прямая привязка к свойству окна и привязка к свойству ViewModel.",
            ["DefaultBinding_WindowBinding"] = "Прямая привязка к свойству окна",
            ["DefaultBinding_ViewModelBinding"] = "Привязка через ViewModel",
            ["DefaultBinding_CurrentWindowValue"] = "Текущее значение свойства окна:",
            ["DefaultBinding_CurrentViewModelValue"] = "Текущее значение свойства ViewModel:",
            ["DefaultBinding_LastUpdated"] = "Последнее обновление: {0:T}",
            ["Message_DataSaved"] = "Данные успешно сохранены.",
            ["Button_ShowMessage"] = "Показать сообщение (внешняя библиотека)",
            ["Triggers_Placeholder"] = "Демонстрация триггеров будет реализована здесь.",
            ["OneWay_Placeholder"] = "Демонстрация односторонней привязки будет реализована здесь."
        };

        private static readonly Dictionary<string, string> En = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["WindowTitle"] = "MVVM Binding Demo",
            ["Language"] = "Language",
            ["Tab_DefaultBinding"] = "Default Binding",
            ["Tab_TwoWayBinding"] = "Two-Way Binding",
            ["Tab_OneTimeBinding"] = "One-Time Binding",
            ["Tab_OneWayBinding"] = "One-Way Binding",
            ["Tab_Triggers"] = "Triggers",
            ["DefaultBinding_Header"] = "DefaultBinding (TextBox, default UpdateSourceTrigger — LostFocus)",
            ["DefaultBinding_Description"] = "Comparison: direct binding to window property and binding to ViewModel property.",
            ["DefaultBinding_WindowBinding"] = "Direct binding to window property",
            ["DefaultBinding_ViewModelBinding"] = "Binding via ViewModel",
            ["DefaultBinding_CurrentWindowValue"] = "Current window property value:",
            ["DefaultBinding_CurrentViewModelValue"] = "Current ViewModel property value:",
            ["DefaultBinding_LastUpdated"] = "Last updated: {0:T}",
            ["Message_DataSaved"] = "Data saved successfully.",
            ["Button_ShowMessage"] = "Show message (external library)",
            ["Triggers_Placeholder"] = "Triggers demo will be implemented here.",
            ["OneWay_Placeholder"] = "One-way binding demo will be implemented here."
        };

        public static string GetString(CultureInfo culture, string key)
        {
            var dict = culture != null && culture.Name.StartsWith("en", StringComparison.OrdinalIgnoreCase) ? En : Ru;
            return dict.TryGetValue(key, out var value) ? value : key;
        }
    }
}
