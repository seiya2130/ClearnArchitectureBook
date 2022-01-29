using System;
using System.Collections.Generic;
using System.Text;

namespace UseCase.Book.Create
{
    public class BookCreateInputData
    {
        public string BookName { get; }

        public BookCreateInputData(string bookName)
        {
            BookName = bookName;
        }
    }
}
