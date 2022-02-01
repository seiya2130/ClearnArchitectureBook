using System;
using System.Collections.Generic;
using System.Text;

namespace UseCase.Book.Create
{
    public interface IBookCreatePresenter
    {
        void Complete(BookCreateOutputData outputData);
    }
}
