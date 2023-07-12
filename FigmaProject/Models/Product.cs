using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class Product : INotifyPropertyChanged
    {
        private Guid id = Guid.NewGuid();
        private string? name;
        private int quantity;
        private DateTime? orderDay;
        private DateTime? deliveryDay;

        public Product(string? name, int quantity, DateTime? orderDay, DateTime? deliveryDay)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.quantity = quantity;
            this.orderDay = orderDay;
            this.deliveryDay = deliveryDay;
        }

        public Guid Id
        {
            get => id;
            set
            {
                id = value;
                propertyChanged();
            }
        }
        public string? ProductName
        {
            get => name;
            set
            {
                name = value;
                propertyChanged();
            }
        }
        public int ProductQuantity
        {
            get => quantity;
            set
            {
                quantity = value;
                propertyChanged();
            }
        }
        public DateTime? OrderDay
        {
            get => orderDay;
            set
            {
                orderDay = value;
                propertyChanged();
            }
        }

        public DateTime? DeliveryDay
        {
            get => deliveryDay;
            set
            {
                deliveryDay = value;
                propertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void propertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
