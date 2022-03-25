using Microsoft.AspNetCore.Mvc;
using SlnBookStore.Infrastructure.DataAccess.Models;
using SlnBookStore.Infrastructure.DataAccess.Repositories;
using SlnBookStore.Services.WebApi.Dto;
using SlnBookStore.Services.WebApi.Mapping;

namespace SlnBookStore.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var result = _bookRepository.GetAll();

            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookReadDto> Add(BookCreateDto bookCreateDto) {
            try
            {
                var book = Mapper.Map(bookCreateDto);

                var resultAdd = _bookRepository.Add(book);

                return Mapper.Map(resultAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
