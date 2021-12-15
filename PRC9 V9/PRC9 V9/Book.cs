using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC9_V9
{
    internal struct Book //структура для хранения информации о книге
    {
        public string Title { get; set; } //название

        public string Author { get; set; } //автор

        public string BookHouse { get; set; } //издательство

        public int NumberOfPages { get; set; } //кол-во страниц

        public Book(string title, string author, string bookhouse, int numberofpages)
        {
            Title = title;
            Author = author;
            BookHouse = bookhouse;
            NumberOfPages = numberofpages;
        }
    }
}
