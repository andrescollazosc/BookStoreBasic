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
            if (bookUpdateDto is null)
                return new Book();

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
            if (book is null)
                return new BookReadDto();

            return new BookReadDto { 
                Author = book.Author,
                CategoryId=book.CategoryId,
                Id = book.Id,
                Isbn = book.Isbn,
                Name = book.Name,
            };
        }

        public static CategoryDto Map(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Description = category.Description,
            };
        }

        public static Category Map(CategoryDto categoryDto)
        {
            if (categoryDto is null)
                return new Category();

            return new Category
            {
                Id = categoryDto.Id,
                Description = categoryDto.Description,
            };
        }

        public static Category Map(CategoryCreateDto categoryCreateDto)
        {
            if (categoryCreateDto is null)
                return new Category();

            return new Category
            {
                Description = categoryCreateDto.Description,
            };
        }

    }
}
