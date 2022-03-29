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
        public ActionResult<IEnumerable<BookReadDto>> GetAll()
        {
            var result = _bookRepository.GetAll().Select(x => Mapper.Map(x)).ToList();

            return Ok(result);
        }

        [HttpGet("bookById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BookReadDto> GetById(string id) {
            var result = Mapper.Map(_bookRepository.GetBookById(id));

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

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookReadDto> Update(BookUpdateDto bookUpdateDto) {

            Book bookToModify = Mapper.Map(bookUpdateDto);
                
            var result = _bookRepository.Update(bookToModify);

            if (result)
            {
                return Mapper.Map(_bookRepository.GetBookById(bookUpdateDto.Id));
            }

            return BadRequest(new BookReadDto());

        }

        [HttpPut("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookReadDto> Delete(string id)
        {

            var result = _bookRepository.Delete(id);

            if (result)
            {
                return NoContent();
            }

            return BadRequest(new BookReadDto());

        }
    }
}
