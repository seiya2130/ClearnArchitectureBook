using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Books
{
    public interface IBookRepository
    {
        void Save(Book book);
        Book FindByBookName(string bookName);
        IEnumerable<Book> FindAll();

    }
}
