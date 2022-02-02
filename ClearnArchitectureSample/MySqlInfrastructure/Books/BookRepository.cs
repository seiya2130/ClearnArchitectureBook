using Domain.Domain.Books;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlInfrastructure.Books
{
    public class BookRepository : IBookRepository
    {
        public void Save(Book book)
        {
            using (var con = new MySqlConnection(Config.ConnectionString))
            {
                con.Open();

                bool isExist;
                using (var com = con.CreateCommand())
                {
                    com.CommandText = "SELECT * FROM t_user WHERE id = @id";
                    com.Parameters.Add(new MySqlParameter("@id", book.Id));
                    var reader = com.ExecuteReader();
                    isExist = reader.Read();
                }

                using (var command = con.CreateCommand())
                {
                    command.CommandText = isExist
                        ? "UPDATE t_user SET username = @username WHERE id = @id"
                        : "INSERT INTO t_user VALUES(@id, @username)";
                    command.Parameters.Add(new MySqlParameter("@id", book.Id));
                    command.Parameters.Add(new MySqlParameter("@username", book.BookName));
                    command.ExecuteNonQuery();
                }
            }
        }

        public Book FindByBookName(string bookName)
        {
            using (var con = new MySqlConnection(Config.ConnectionString))
            {
                con.Open();
                using (var com = con.CreateCommand())
                {
                    com.CommandText = "SELECT * FROM t_user WHERE username = @username";
                    com.Parameters.Add(new MySqlParameter("@username", bookName));
                    var reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;

                        return new Book(
                            id,
                            bookName
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Book> FindAll()
        {
            using (var con = new MySqlConnection(Config.ConnectionString))
            {
                con.Open();
                using (var com = con.CreateCommand())
                {
                    com.CommandText = "SELECT * FROM t_user";
                    var reader = com.ExecuteReader();
                    var results = new List<Book>();
                    while (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var bookName = reader["name"] as string;
                        var book = new Book(
                            id,
                            bookName
                        );
                        results.Add(book);
                    }
                    return results;
                }
            }
        }
    }
}
