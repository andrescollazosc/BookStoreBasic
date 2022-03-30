using Microsoft.AspNetCore.Mvc;
using SlnBookStore.Infrastructure.DataAccess.Repositories;
using SlnBookStore.Services.WebApi.Dto;
using SlnBookStore.Services.WebApi.Mapping;

namespace SlnBookStore.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet("categories")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                var categories = _categoryRepository.GetCategories().Select(category => Mapper.Map(category));

                return categories.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("category/{id}")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CategoryDto> GetById(string id)
        {
            try
            {
                var category = _categoryRepository.GetCategoryById(id);

                if (category is null)
                    return NotFound();

                return Mapper.Map(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Add(CategoryCreateDto categoryCreateDto)
        {
            try
            {
                var hasCategory = _categoryRepository.AddCategory(Mapper.Map(categoryCreateDto));

                return hasCategory;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Update(CategoryDto categoryDto)
        {
            try
            {
                var hasCategory = _categoryRepository.UpdateCategory(Mapper.Map(categoryDto));

                return hasCategory;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
