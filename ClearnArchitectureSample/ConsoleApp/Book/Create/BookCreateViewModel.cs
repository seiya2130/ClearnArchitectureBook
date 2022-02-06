
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Book.Create
{
    public class BookCreateViewModel
    {
        public string BookId { get; }
        public string CreatedData { get; }

        public BookCreateViewModel(string bookId, string createDate)
        {
            BookId = bookId;
            CreatedData = createDate;
        }

    }
}
