using System.ComponentModel.DataAnnotations;

namespace SlnBookStore.Services.WebApi.Dto
{
    public class BookCreateDto
    {
        [Required(ErrorMessage = "La categoria es obligatoria")]
        [MaxLength(60)]
        [MinLength(10)]
        public string? CategoryId { get; set; }

        [Required(ErrorMessage = "EL nombre es obligatorio")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "EL Isbn es obligatorio")]
        public string? Isbn { get; set; }
        public string? Author { get; set; }
    }
}
