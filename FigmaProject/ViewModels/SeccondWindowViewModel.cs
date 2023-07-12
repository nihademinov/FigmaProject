using FigmaProject.Commands;
using FigmaProject.DataBase;
using FigmaProject.Models;
using FigmaProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FigmaProject.ViewModels
{
    public class SeccondWindowViewModel
    {
        public AllDataBase alldb = new();
        private User? user1;
        private string? username1;
        public RealCommand? LogOutButtonCommand { get; set; }
        public RealCommand? NewClientButtonCommand { get; set; }
        public RealCommand? SeeAllClientButtonCommand { get; set; }



        public SeccondWindowViewModel()
        {
            user1 = alldb._allUsers![0];
            username1 = user1!._username;
            LogOutButtonCommand = new RealCommand(logoutbtn);
            NewClientButtonCommand = new RealCommand(newClientbtn);
            SeeAllClientButtonCommand = new RealCommand(seeAllClient);
        }


        public User? user
        {
            get => user1;
            set => user1 =value;
        }


        public string? username
        {
            get { return username1; }
            set { username1 = value; }
        }

        public void logoutbtn(object? parametr)
        {
            MessageBoxResult result = MessageBox.Show("Quit","Are you sure log out your account?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                MainView main = new();
                var window = Application.Current.Windows[0];
                window.Close();
                main.ShowDialog();
            }
        }

        public void newClientbtn(object? parametr)
        {
            ThridWindowView thridWindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            thridWindow.ShowDialog();
        }

        public void seeAllClient(object? paramter)
        {
            SeeAllClientsWindowView seeAllClientsWindowView = new();
            var window = Application.Current.Windows[0];
            window.Close();
            seeAllClientsWindowView.ShowDialog();   
        }




    }
}
