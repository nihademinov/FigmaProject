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
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FigmaProject.ViewModels
{
    public class ThridwindowViewModel:INotifyPropertyChanged
    {
        public RealCommand? RegisterButtonCommand { get; set; }
        public RealCommand? HomeButtonCommand { get; set; }
        public AllDataBase? alldb = new();

        private string? _txtBoxName;
        private string? _txtBoxSurname;
        private string? _txtBoxPhone;
        private string? _txtBoxCompany;
        private string? _txtBoxPlace;
        private string? _txtBoxDay;
        private string? _txtBoxMonth;
        private string? _txtBoxYear;
        private string? _txtBoxDescription;

        public string? txtBoxName
        {
            get { return _txtBoxName; }
            set { _txtBoxName = value; 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxName));
            }
        }
        public string? txtBoxSurname
        {
            get { return _txtBoxSurname; }
            set { _txtBoxSurname = value; 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxSurname));
            }
        }
        public string? txtBoxPhone
        {
            get { return _txtBoxPhone; }
            set { _txtBoxPhone = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxPhone));
            }
        }
        public string? txtBoxCompany
        {
            get { return _txtBoxCompany; }
            set { _txtBoxCompany = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxCompany));
            }
        }
        public string? txtBoxPlace
        {
            get { return _txtBoxPlace; }
            set { _txtBoxPlace = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxPlace));
            }
        }

        public string? txtBoxDay
        {
            get { return _txtBoxDay; }
            set { _txtBoxDay = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxDay));
            }
        }

        public string? txtBoxMonth
        {
            get { return _txtBoxMonth; }
            set
            {
                _txtBoxMonth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxMonth));
            }
        }

        public string? txtBoxYear
        {
            get { return _txtBoxYear; }
            set
            {
                _txtBoxYear = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxYear));
            }
        }

        public string? txtBoxDescription
        {
            get { return _txtBoxDescription; }
            set 
            { 

                _txtBoxDescription = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_txtBoxDescription));
            }
        }


        string? patternNumber = @"^\+\d{3}\d{3}\d{6}$";

        public event PropertyChangedEventHandler? PropertyChanged;

        public ThridwindowViewModel()
        {
            _txtBoxName = "What is the name of the client?";
            _txtBoxSurname = "What is the surname of the client?";
            _txtBoxPhone = "What is the phone number of the client?";
            _txtBoxCompany = "Which company does the person belong to?";
            _txtBoxPlace = "Where did he/she found me?";
            _txtBoxDay = "Day";
            _txtBoxMonth = "Month";
            _txtBoxYear = "Year";
            _txtBoxDescription = "Write how do you know him/her";

            RegisterButtonCommand = new RealCommand(registerBtn);
            HomeButtonCommand = new RealCommand(homeBtn);
        }

        public void registerBtn(object? parametr)
        {
            try
            {
                if (!Regex.IsMatch(_txtBoxPhone!, patternNumber!))
                {
                    throw new Exception();
                }
                DateTime date = DateTime.ParseExact($"{_txtBoxDay}-{_txtBoxMonth}-{_txtBoxYear}", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Client newClinet = new(_txtBoxName, _txtBoxSurname, _txtBoxPhone, _txtBoxCompany, _txtBoxPlace, date, _txtBoxDescription);
                //alldb!.Add(newClinet);

                //using FileStream fs = new FileStream("AllClients.json", FileMode.OpenOrCreate);
                //fs.Close();
                string tempClient = File.ReadAllText("AllClients.json");

                ObservableCollection<Client>? allClients = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Client>>(tempClient);
                if(allClients == null)
                {
                    alldb!.Add(newClinet);   
                }
                else
                {
                    alldb!.Property_AllClients = allClients!;
                    alldb.Add(newClinet);

                }

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                File.WriteAllText("AllClients.json", JsonSerializer.Serialize(alldb.Property_AllClients, options));
                MessageBox.Show("Client successfully created","Info",MessageBoxButton.OK,MessageBoxImage.Information);
                SeccondWindowView seccondWindow = new();
                var window = Application.Current.Windows[0];
                window.Close();
                seccondWindow.ShowDialog();

            }
            catch (Exception )
            {
                MessageBox.Show("Something went wrong check please","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                
            }
        }

        public void homeBtn(object? paramter)
        {
            SeccondWindowView seccondWindow = new();
            var window = Application.Current.Windows[0];
            window.Close();
            seccondWindow.ShowDialog();
        }

    }
}
