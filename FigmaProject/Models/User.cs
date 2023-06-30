using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class User
    {
        public string? _username { get; set; }
        public string? _password { get; set; }
        public Client? _client { get; set; }
    }
}
