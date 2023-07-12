using FigmaProject.Commands;
using FigmaProject.DataBase;
using FigmaProject.Models;
using FigmaProject.Views;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace FigmaProject.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public RealCommand? LoadButtonCommand { get; set; }
    public AllDataBase alldb = new();
    private string? textBoxusername1;
    private string? textboxpassword1;
    public User? selectedUser = null;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string? textBoxusername
    {
        get => textBoxusername1;
        set
        {
            textBoxusername1 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(textBoxusername1));
        }
    }
    public string? textboxpassword
    {
        get => textboxpassword1;
        set
        {
            textboxpassword1 = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(textboxpassword1));
        }
    }




    public MainViewModel()
    {
        this.textBoxusername = "enter username";
        this.textboxpassword = "enter password";
        LoadButtonCommand = new RealCommand(loadButton);

    }

   
 

    public void loadButton(object? parametr)
    {
        bool check = alldb.findUser(textBoxusername, textboxpassword);
        if(check)
        {
            SeccondWindowView seccondWindow = new();
            seccondWindow.DataContext = new SeccondWindowViewModel();
            var window = Application.Current.Windows[0];
            window.Close();
            seccondWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("User not found","Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }





}



