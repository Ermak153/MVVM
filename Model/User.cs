using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class User
    {
        public User(int id, string name, string family) {
            Id = id;
            Name = name;
            Family = family;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        //public List<Book> Books { get; set; } = new List<Book>();
    }
}
