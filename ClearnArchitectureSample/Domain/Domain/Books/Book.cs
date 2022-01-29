using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Books
{
    public class Book
    {
        public string Id { get; }
        public string BookName { get; }

        public Book(string bookName)
        {
            Id = Guid.NewGuid().ToString();
            BookName = bookName;
        }
        public Book(string id, string bookName)
        {
            Id = id;
            BookName = bookName;
        }

    }
}
