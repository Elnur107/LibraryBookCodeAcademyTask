using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

class Book
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public double Price { get; set; }
    public string Code { get; set; }

    public Book(string name, string author, int pageCount, double price)
    {
        Name = name;
        AuthorName = author;
        PageCount = pageCount;
        Price = price;
        Code = $"{name[0]}{author[0]}{Guid.NewGuid().ToString().Substring(0, 4)}";
    }
}