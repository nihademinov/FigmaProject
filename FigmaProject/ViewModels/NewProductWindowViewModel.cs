using FigmaProject.Commands;
using FigmaProject.DataBase;
using FigmaProject.Models;
using FigmaProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace FigmaProject.ViewModels
{
    public class NewProductWindowViewModel : INotifyPropertyChanged
    {
        public AllDataBase? alldb = new();


        private string? productName;
        private string? productQuantity;
        private string? orderDay;
        private string? orderMonth;
        private string? orderYear;
        private string? deliveryDay;
        private string? deliveryMonth;
        private string? deliveryYear;


        public string? OrderDay
        {
            get { return orderDay; }
            set
            {
                orderDay = value;
                propertyChanged();
            }
        }

        public string? OrderMonth
        {
            get { return orderMonth; }
            set
            {
                orderMonth = value;
                propertyChanged();
            }
        }

        public string? OrderYear
        {
            get { return orderYear; }
            set
            {
                orderYear = value;
                propertyChanged();
            }
        }

        public string? DeliveryDay
        {
            get { return deliveryDay; }
            set
            {
                deliveryDay = value;
                propertyChanged();
            }
        }

        public string? DeliveryMonth
        {
            get { return deliveryMonth; }
            set
            {
                deliveryMonth = value;
                propertyChanged();
            }
        }

        public string? DeliveryYear
        {
            get { return deliveryYear; }
            set
            {
                deliveryYear = value;
                propertyChanged();
            }
        }

        public string? ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                propertyChanged();
            }
        }


        public string? ProductQuantity
        {
            get { return productQuantity; }
            set
            {
                productQuantity = value;
                propertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public RealCommand? RegisterButtonCommand { get; set; }
        public RealCommand? HomeButtonCommand { get; set; }


        public NewProductWindowViewModel()
        {
            productName = "Type the order name same with the order blank";
            productQuantity = "How many do you want?";
            orderDay = "Day";
            orderMonth = "Month";
            orderYear = "Year";
            deliveryDay = "Day";
            deliveryMonth = "Month";
            deliveryYear = "Year";
            

            HomeButtonCommand = new RealCommand(homeBtn);
            RegisterButtonCommand = new RealCommand(registerBtn);
        }


        public void propertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void homeBtn(object? parametr)
        {
            SeeClientProductsWindowView clientsProductwindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            clientsProductwindow.ShowDialog();
        }

        public void registerBtn(object? parametr)
        {

            try
            {
                DateTime dateOrder = DateTime.ParseExact($"{orderDay}-{orderMonth}-{orderYear}", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime dateDelivery = DateTime.ParseExact($"{deliveryDay}-{deliveryMonth}-{deliveryYear}", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                int tempQunatity = Convert.ToInt32(productQuantity);
                Product newProduct = new Product(ProductName,tempQunatity , dateOrder, dateDelivery);


                using FileStream fs = new FileStream("Allproducts.json", FileMode.OpenOrCreate);
                fs.Close();
                string tempClient = File.ReadAllText("Allproducts.json");

                ObservableCollection<Client>? allProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Client>>(tempClient);
                if (allProducts == null)
                {
                    alldb!.Add(newProduct);
                }
                else
                {
                    alldb!.Property_AllClients = allProducts!;
                    alldb.Add(newProduct);

                }

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                File.WriteAllText("Allproducts.json", JsonSerializer.Serialize(alldb.Property_AllProducts, options));
                MessageBox.Show("Product successfully created", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                SeccondWindowView seccondWindow = new();
                var window = Application.Current.Windows[0];
                window.Close();
                seccondWindow.ShowDialog();

            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong check please", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

    }
}
