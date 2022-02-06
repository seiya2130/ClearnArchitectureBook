using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MySqlInfrastructure.Books;
using UseCase.Book.Create;
using Domain.Domain.Books;
using InMemoryInfrastructure.Books;

namespace ConsoleApp
{
    public class Startup
    {
        public static IServiceCollection ServiceCollection { get; } = new ServiceCollection();

        public static void Run()
        {
#if DEBUG
            setupDebug();
#else
            setupProduct();
#endif
        }

        private static void setupProduct()
        {
            ServiceCollection.AddTransient<IBookRepository, BookRepository>();
            ServiceCollection.AddTransient<IBookCreatePresenter, BookCreatePresenter>();
            ServiceCollection.AddTransient<IBookCreateUseCase, BookCreateInteractor>();
            ServiceCollection.AddTransient<UserController>();
        }

        private static void setupDebug()
        {
            ServiceCollection.AddTransient<IBookRepository, InMemoryBookRepository>();
            ServiceCollection.AddTransient<IBookCreatePresenter, BookCreatePresenter>();
            ServiceCollection.AddTransient<IBookCreateUseCase, BookCreateInteractor>();
            ServiceCollection.AddTransient<UsController>();
        }
    }
}
