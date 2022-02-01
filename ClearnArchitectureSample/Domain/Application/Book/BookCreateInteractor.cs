using System;
using System.Collections.Generic;
using System.Text;
using UseCase.Book.Create;
using Domain.Domain.Books;

namespace Domain.Application.Book
{
    public class BookCreateInteractor : IBookCreateUseCase
    {
        private readonly IBookRepository bookRepository;
        private readonly IBookCreatePresenter presenter;

        public BookCreateInteractor(IBookRepository bookRepository, IBookCreatePresenter presenter)
        {
            this.bookRepository = bookRepository;
            this.presenter = presenter;
        }

        public void Handle(BookCreateInputData inputData)
        {
            var bookName = inputData.BookName;
            var duplicateBook = bookRepository.FindByBookName(bookName);

            if(duplicateBook != null)
            {
                throw new Exception("duplicated");
            }

            var book = new Domain.Books.Book(bookName);
            bookRepository.Save(book);

            var outputData = new BookCreateOutputData(book.Id, DateTime.Now);
            presenter.Complete(outputData);

        }
    }
}
