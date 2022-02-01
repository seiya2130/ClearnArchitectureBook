using Domain.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InMemoryInfrastructure.Books
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly Dictionary<string, Book> data = new Dictionary<string, Book>();

        public void Save(Book book)
        {
            data[book.Id] = CloneBook(book);
        }

        public Book FindByBookName(string bookName)
        {
            return data.Select(x => x.Value).FirstOrDefault(x => x.BookName == bookName);
        }

        public IEnumerable<Book> FindAll()
        {
            return data.Values;
        }

        private Book CloneBook(Book book)
        {
            return new Book(book.Id, book.BookName);
        }
    }
}
