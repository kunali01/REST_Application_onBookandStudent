using REST_Application_Demo.Data;
using REST_Application_Demo.Models;
using System.Linq;

namespace REST_Application_Demo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.FirstOrDefault(b => b.BookId == id);
        }

        public IEnumerable<Book> GetBookByAuthor(string authorName)
        {
            return _dbContext.Books.Where(b => b.Author.Contains(authorName)).ToList();
        }

        public int AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            return _dbContext.SaveChanges();
        }

        public int UpdateBook(Book book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook != null)
            {
                _dbContext.Entry(existingBook).CurrentValues.SetValues(book);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public int DeleteBook(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                return _dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
