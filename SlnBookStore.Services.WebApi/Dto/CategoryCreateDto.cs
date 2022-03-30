using System.ComponentModel.DataAnnotations;

namespace SlnBookStore.Services.WebApi.Dto
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string? Description { get; set; }
    }
}
