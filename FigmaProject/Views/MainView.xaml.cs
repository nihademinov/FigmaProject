using FigmaProject.ViewModels;
using System.Windows;

namespace FigmaProject.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

        }

        //private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //    TextBox textBox = (TextBox)sender;
        //    textBox.Foreground = new SolidColorBrush(Colors.Black);
        //    textBox.Padding = new Thickness(140, 15, 0, 0);
        //    textBox.Text = "";
        //}

        //private void ClearTextBoxCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    TextBox? textBox = e.Source as TextBox;
        //    if (textBox != null)
        //    {
        //        var viewModel = DataContext as MainViewModel;
        //        viewModel?.ClearTextBoxCommand!.Execute(textBox);
        //    }
        //}

    }
}
