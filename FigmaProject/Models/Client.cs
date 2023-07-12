using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class Client : INotifyPropertyChanged
    {
        private Guid id = Guid.NewGuid();
        private string? name;
        private string? surname;
        private string? phone;
        private DateTime? registerDate;
        private ObservableCollection<Product?>? products;
        private string? companyName;
        private string? description;
        private string? place;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Guid Id
        {
            get => id;
            set
            {
                id = value;
                propertyChanged();

            }

        }
        public string? Name
        {
            get => name;
            set
            {
                name = value;
                propertyChanged();
            }
        }
        public string? Surname
        {
            get => surname;
            set
            {
                surname = value;
                propertyChanged();

            }
        }
        public string? Phone
        {
            get => phone;
            set
            {
                phone = value;
                propertyChanged();

            }
        }
        public DateTime? RegisterDate
        {
            get => registerDate;
            set { registerDate = value;
                propertyChanged();
            }
        }
        public ObservableCollection<Product?>? Products { get => products;
            set { products = value; 
                propertyChanged();
            }
        }
        public string? CompanyName
        {
            get => companyName;
            set
            {
                companyName = value;
                propertyChanged();

            }
        }
        public string? Description
        {
            get => description;
            set
            {
                description = value;
                propertyChanged();

            }
        }
        public string? Place
        {
            get => place;
            set
            {
                place = value;
                propertyChanged();

            }
        }
        public Client(string? name, string? surname, string? phone, string? companyname, string? place, DateTime? registerDate, string? description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Phone = phone;
            CompanyName = companyname;
            Place = place;
            RegisterDate = registerDate;
            Description = description;
        }

        public void propertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
