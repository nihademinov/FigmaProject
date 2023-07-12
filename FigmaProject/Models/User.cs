using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.Models
{
    public class User
    {
        public User(string? username, string? password)
        {
            _username = username;
            _password = password;
        }

        public string? _username { get; set; }
        public string? _password { get; set; }
        public ObservableCollection <Client?>? _client { get; set; }


    }
}
