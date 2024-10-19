using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FormWPF
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : Window
    {
        public bool IsDeleted { get; private set; }
        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsDeleted = true; // Устанавливаем флаг на удаление
            Close(); // Закрываем окно
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsDeleted = false; // Устанавливаем флаг на сохранение
            Close(); // Закрываем окно
        }
    }
}
