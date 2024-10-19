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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int argument1;
        public int argument2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            argument1 = Convert.ToInt32(Argument1TextBox.Text);
            argument2 = Convert.ToInt32(Argument2TextBox.Text);
            int plus = argument1 + argument2;
            int ymnoz = argument1 * argument2;
            BlockPlus.Text = $"{argument1} + {argument2} = {plus}";
            BlockYmnoz.Text = $"{argument1} * {argument2} = {ymnoz}";

        }
    }
}
