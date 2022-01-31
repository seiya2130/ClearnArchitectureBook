using System;
using System.Collections.Generic;
using System.Text;

namespace UseCase.Book.Create
{
    public class BookCreateOutputData
    {
        public BookCreateOutputData(string bookId, DateTime created)
        {
            BookId = bookId;
            Created = created;
        }
        public string BookId { get; }
        public DateTime Created { get; }
    }
}
