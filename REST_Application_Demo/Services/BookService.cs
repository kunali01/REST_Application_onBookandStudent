using REST_Application_Demo.Models;
using REST_Application_Demo.Repositories;

namespace REST_Application_Demo.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public IEnumerable<Book> GetBookByAuthor(string authorName)
        {
            return _bookRepository.GetBookByAuthor(authorName);
        }

        public int AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }

        public int UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }

        public int DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }
    }
}
