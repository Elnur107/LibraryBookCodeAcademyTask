using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models;

class Library
{
    public List<Book> Books { get; private set; }

    public Library()
    {
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public Book GetBook(string name = null, string author = null)
    {
        return Books.Find(book => book.Name == name && book.AuthorName == author);
    }

    public List<Book> FindAllBooks(string author = null)
    {
        return Books.FindAll(book => book.AuthorName == author);
    }

    public int RemoveAllBooks(string author = null)
    {
        List<Book> removedBooks = Books.FindAll(book => book.AuthorName == author);
        Books.RemoveAll(book => book.AuthorName == author);
        return removedBooks.Count;
    }
}

class Order
{
    public int Id { get; set; }
    public List<Book> Books { get; private set; }
    public double TotalPrice { get; private set; }
    public DateTime Date { get; private set; }

    public Order()
    {
        Id = GenerateOrderId();
        Books = new List<Book>();
        Date = DateTime.Now;
    }

    private int GenerateOrderId()
    {
        return new Random().Next(1000, 9999);
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public double CalculateTotalPrice()
    {
        TotalPrice = Books.Sum(book => book.Price);
        return TotalPrice;
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        Book book1 = new Book("Cinayet ve ceza", "Fyodor  Dostoyevski ", 300, 29.99);
        library.AddBook(book1);

        Book foundBook = library.GetBook(name: "Cinayet ve ceza", author: "Fyodor  Dostoyevski ");

        List<Book> allBooks = library.FindAllBooks(author: "Fyodor  Dostoyevski ");

        int removedCount = library.RemoveAllBooks(author: "Fyodor  Dostoyevski ");

        Order order = new Order();
        order.AddBook(book1);

        double totalPrice = order.CalculateTotalPrice();


        Console.WriteLine($"Kitabxana: {book1.Name} elave edildi.");
        Console.WriteLine($"Tapilan Kitab: {foundBook.Name} - {foundBook.AuthorName}");
        Console.WriteLine($"Tapilan Kitablarin Sayi: {allBooks.Count}");
        Console.WriteLine($"Silinen Kitablarin Sayi: {removedCount}");
        Console.WriteLine($"Sifarisin Umumi Qiymeti: {totalPrice}");
    }
}