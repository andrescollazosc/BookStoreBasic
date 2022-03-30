using System.ComponentModel.DataAnnotations;

namespace SlnBookStore.Services.WebApi.Dto
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "El id es obligatorio.")]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string? Description { get; set; }
    }
}
