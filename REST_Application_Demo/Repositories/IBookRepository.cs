using REST_Application_Demo.Models;

namespace REST_Application_Demo.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        IEnumerable<Book> GetBookByAuthor(string authorName);
        int AddBook(Book book);
        int UpdateBook(Book book);
        int DeleteBook(int id);
    }
}
