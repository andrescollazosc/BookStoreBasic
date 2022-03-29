using SlnBookStore.Infrastructure.DataAccess.Models;
using SlnBookStore.Services.WebApi.Dto;

namespace SlnBookStore.Services.WebApi.Mapping
{
    public class Mapper
    {
        public static Book Map(BookCreateDto bookCreateDto) {
            return new Book
            {
                Author = bookCreateDto.Author,
                CategoryId = bookCreateDto.CategoryId,
                Name = bookCreateDto.Name,
                Isbn = bookCreateDto.Isbn
            };
        }

        public static Book Map(BookUpdateDto bookUpdateDto)
        {
            return new Book
            {
                Author = bookUpdateDto.Author,
                CategoryId = bookUpdateDto.CategoryId,
                Name = bookUpdateDto.Name,
                Isbn = bookUpdateDto.Isbn,
                PublicationDate = bookUpdateDto.PublicationDate,
                Id = bookUpdateDto.Id,
            };
        }

        public static BookReadDto Map(Book book)
        {
            return new BookReadDto { 
                Author = book.Author,
                CategoryId=book.CategoryId,
                Id = book.Id,
                Isbn = book.Isbn,
                Name = book.Name,
            };
        }


    }
}
