using FigmaProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaProject.DataBase
{
    public class AllDataBase : IRepository<User>, IRepository<Client>, IRepository<Product>
    {
        public ObservableCollection<User?>? _allUsers { get; set; }
        private ObservableCollection<Client?>? _allClients;
        private ObservableCollection<Product?>? _allProducts;

        public AllDataBase()
        {
            string allclinets = File.ReadAllText("AllClients.json");

            ObservableCollection<Client?>? allClientsTemp = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Client?>>(allclinets);
            Property_AllClients = allClientsTemp;


          


            _allUsers = new()
            {
                new User("a","a")

            };

        }

        //      public ObservableCollection<User?>? Property_AllUsers
        //{
        //	get { return _allUsers; }
        //	set { _allUsers = value; }
        //}

        public ObservableCollection<Client?>? Property_AllClients
        {
            get { return _allClients; }
            set { _allClients = value; }
        }

        public ObservableCollection<Product?>? Property_AllProducts
        {
            get { return _allProducts; }
            set { _allProducts = value; }
        }


        //-------------------------------User-----------------------------------------------

        public void Add(User entity)
        {
            if(entity != null)
            {
                _allUsers!.Add(entity);
            }
        }

        public User? Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<User>? GetList(Func<User, bool>? predicate = null)
        {
            return _allUsers!;
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool findUser(string? username, string? password)
        {
            bool check = false;
            if (_allUsers != null)
            {
                foreach (var item in _allUsers)
                {
                    if (item!._username == username && item!._password == password)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }


        //-------------------------------Client-----------------------------------------------

        public Client returnSelectedClient(Guid id)
        {
            if(_allClients != null)
            {
                foreach (var item in _allClients)
                {
                    if(item!.Id == id)
                    {
                        return item;
                    }
                }

            }
            return null!;
        }


        public Client? Get(Func<Client, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Client>? GetList(Func<Client, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Client entity)
        {
            _allClients!.Add(entity);
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Client entity)
        {
            throw new NotImplementedException();
        }




        //-------------------------------PRoduct-----------------------------------------------
        public Product? Get(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Product>? GetList(Func<Product, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            _allProducts!.Add(entity);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
