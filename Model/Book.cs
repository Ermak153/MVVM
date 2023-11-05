using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WpfApp1.Model
{
    internal class Book
    {
        public Book(string title, string author, DateTime year, int count) { 
            Title = title;
            Author = author;
            Year = year;
            Count = count;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Year { get; set; }
        public int Count { get; set; }
    }
}
