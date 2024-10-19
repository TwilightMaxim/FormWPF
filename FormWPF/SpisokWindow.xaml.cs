using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FormWPF
{
    /// <summary>
    /// Логика взаимодействия для _2.xaml
    /// </summary>
    public partial class SpisokWindow : Window
    {
        ObservableCollection<string> names;
        public string SelectedName { get; set; }
        public SpisokWindow()
        {
            InitializeComponent();
            names = new ObservableCollection<string> { "Алексей", "Андрей", "Варвара" };
            NameList.ItemsSource = names;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Argument1TextBox.Text;
            name = ProcessName(name);
            names.Add(name);
            Argument1TextBox.Clear();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Проверяем, есть ли выбранный элемент в ListBox
            if (NameList.SelectedItem != null)
            {
                string selectedName = NameList.SelectedItem as string;
                names.Remove(selectedName); // Удаляем выделенный элемент из ObservableCollection
            }
        }
        private string ProcessName(string name)
        {
            name = name.Trim(); // Удаляем пробелы по краям
            name = name.Replace(" ", ""); // Удаляем пробелы внутри строки

            // Преобразование CapsLock: если все буквы заглавные, то преобразуем к строчным + первая заглавная
            if (name.ToUpper() == name)
            {
                name = name.ToLower(); // Переводим в строчные
                name = char.ToUpper(name[0]) + name.Substring(1); // Первая буква заглавная
                return name;
            }

            // Преобразование первой буквы в заглавную, а остальных в строчные
            if (!string.IsNullOrEmpty(name))
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower(); // Преобразование "заборчика"
            }

            return name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = Argument1TextBox.Text;

            // Регулярное выражение для поиска нежелательных символов
            string pattern = @"[0-9\p{P}\(\)\[\]{}+\-*/=]";
            if (Regex.IsMatch(name, pattern))
            {
                // Открываем модальное окно подтверждения
                ConfirmationDialog dialog = new ConfirmationDialog();
                dialog.Owner = this; // Устанавливаем родительское окно
                dialog.ShowDialog();

                // Проверяем результат
                if (dialog.IsDeleted)
                {
                    Argument1TextBox.Clear(); // Очищаем текстовое поле после удаления
                }
            }
            else
            {
                MessageBox.Show("Имя не содержит лишних символов.", "Проверка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
