using FigmaProject.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FigmaProject.ViewModels
{
    public class MainViewModel
    {
        public RealCommand? ClearTextBoxCommand { get; set; }
        public MainViewModel()
        {
            ClearTextBoxCommand = new RealCommand(ClearTextBox!,canEdit);

        }

        public bool canEdit(object? param)
        {
            return true;
        }

        private void ClearTextBox(object parameter)
        {
            TextBox? textBox = parameter as TextBox;
            if (textBox != null)
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            textBox.Foreground = new SolidColorBrush(Colors.Black);
            textBox.Padding = new Thickness(140, 15, 0, 0);
            textBox.Text = "";
        }


    }
}



