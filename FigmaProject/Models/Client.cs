using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? _name { get; set; }
        public string? _surname { get; set; }
        public string? _phone { get; set; }
        public DateTime? _registerDate { get; set; }
        public Product? _product { get; set; }

    }
}
