using FigmaProject.ViewModels;
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

namespace FigmaProject.Views
{
    /// <summary>
    /// Interaction logic for NewProductWindowView.xaml
    /// </summary>
    public partial class NewProductWindowView : Window
    {

        private string? tempDefaultValue;
        private string? tempDefaultValue2;
        public NewProductWindowView()
        {
            DataContext = new NewProductWindowViewModel();
            InitializeComponent();
        }


        private void TextBox_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Foreground is SolidColorBrush foregroundBrush && foregroundBrush.Color == Colors.LightGray)
            {
                tempDefaultValue2 = tempDefaultValue;
                tempDefaultValue = textBox.Text;
                textBox.Clear();
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.LightGray);

                textBox.Text = tempDefaultValue2;
            }

        }
    }
}
