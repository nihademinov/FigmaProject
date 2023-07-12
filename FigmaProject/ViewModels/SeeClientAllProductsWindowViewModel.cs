using FigmaProject.Commands;
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
using System.Threading.Tasks;
using System.Windows;

namespace FigmaProject.ViewModels
{
    public class SeeClientAllProductsWindowViewModel : INotifyPropertyChanged
    {
        private Client? selectedClient;
        
        public RealCommand? NewOrderCommand { get; set; }
        public RealCommand? HomeCommand { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public Client SelectedClient
        {
            get { return selectedClient!; }
            set
            {
                selectedClient = value;
                propertyChanged();
            }
        }


        public SeeClientAllProductsWindowViewModel(Client selectedClient)
        {
            SelectedClient = selectedClient;
            NewOrderCommand = new RealCommand(newProduct);
            HomeCommand = new RealCommand(homeBtn);
            string allproducts = File.ReadAllText("Allproducts.json");

            ObservableCollection<Product?>? allproductsTemp = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Product?>>(allproducts);
            if(allproductsTemp != null)
            {
                selectedClient.Products = allproductsTemp;

            }

        }
        public SeeClientAllProductsWindowViewModel()
        {

        }

        public void propertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void newProduct(object? parametr)
        {
            NewProductWindowView newProductWindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            newProductWindow.ShowDialog();
           
        }

        public void homeBtn(object? parametr)
        {
            SeeAllClientsWindowView allclientswindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            allclientswindow.ShowDialog();
        }

    }
}
