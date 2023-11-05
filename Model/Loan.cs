using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class Loan
    {
        public Loan(User user, Book book) {
            User = user;
            Book = book;
        }
        public User User { get; }
        public Book Book { get; }
    }
}
