using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? _name { get; set; }
        public int _quantity  { get; set; }
        public DateTime? _orderDay  { get; set; }


    }
}
