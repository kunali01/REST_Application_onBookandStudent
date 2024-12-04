using Microsoft.AspNetCore.Mvc;
using REST_Application_Demo.Models;
using REST_Application_Demo.Services;


namespace REST_Application_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetBooks")]
        public IActionResult GetBooks()
        {
            try
            {
                var books = _service.GetBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _service.GetBookById(id);
                if (book == null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBookByAuthor/{authorName}")]
        public IActionResult GetBookByAuthor(string authorName)
        {
            try
            {
                var books = _service.GetBookByAuthor(authorName);
                if (books == null || !books.Any())
                    return NotFound();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                var result = _service.AddBook(book);
                if (result > 0)
                    return StatusCode(StatusCodes.Status201Created);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            try
            {
                var result = _service.UpdateBook(book);
                if (result > 0)
                    return Ok();

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var result = _service.DeleteBook(id);
                if (result > 0)
                    return Ok();

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
