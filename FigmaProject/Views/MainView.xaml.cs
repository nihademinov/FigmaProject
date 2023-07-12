using FigmaProject.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FigmaProject.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        //public string tempDefaultValue = "";
        public string? tempDefaultValue;
        private string? tempDefaultValue2;


        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();


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
