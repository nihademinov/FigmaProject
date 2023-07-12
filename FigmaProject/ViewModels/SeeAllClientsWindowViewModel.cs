using FigmaProject.DataBase;
using FigmaProject.Models;
using FigmaProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;



using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;
using FigmaProject.Commands;

namespace FigmaProject.ViewModels
{
    public class SeeAllClientsWindowViewModel : INotifyPropertyChanged
    {
        public AllDataBase alldb = new();
        private ObservableCollection<Client?>? allClients1;

        public event PropertyChangedEventHandler? PropertyChanged;
        public RealCommand? MoreButtonCommand { get; set; }
        public RealCommand? HomeBtnCommand { get; set; }
        public RealCommand? NewBtnCommand { get; set; }



        public ObservableCollection<Client?>? allClients
        {
            get => allClients1;
            set
            {
                allClients1 = value;
                propertyChanged();
            }

        }



        public SeeAllClientsWindowViewModel()
        {
            
            allClients = alldb.Property_AllClients;
            HomeBtnCommand = new RealCommand(homeBtnCommand);
            MoreButtonCommand = new RealCommand(moreCommand);
            NewBtnCommand = new RealCommand(newClient);

        }

        public void moreCommand(object? parametr)
        {
            Client selectedClient = alldb.returnSelectedClient((Guid) parametr!);
            SeeClientProductsWindowView clientProducts = new();
            clientProducts.DataContext = new SeeClientAllProductsWindowViewModel(selectedClient);
            var window = Application.Current.Windows[0];
            window.Close();
            clientProducts.ShowDialog();
        }

        public void propertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void homeBtnCommand(object? parametr)
        {
            SeccondWindowView seccondWindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            seccondWindow.ShowDialog();
        }

        public void newClient(object? parametr)
        {
            ThridWindowView thridWindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            thridWindow.ShowDialog();

        }

    }
}
