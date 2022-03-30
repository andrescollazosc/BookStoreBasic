using SlnBookStore.Infrastructure.DataAccess.Models;

namespace SlnBookStore.Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository
    {
        private readonly bookDBContext _context;

        public CategoryRepository()
        {
            _context = new bookDBContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _context.Categories;

            return categories;
        }

        public Category GetCategoryById(string id)
        {
            var category = _context.Categories.FirstOrDefault(category => category.Id == id);

            return category;
        }

        public bool AddCategory(Category category)
        {
            category.Id = Guid.NewGuid().ToString();
            _context.Categories.Add(category);

            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            var categoryEntity = GetCategoryById(category.Id);

            categoryEntity.Description = category.Description;

            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            var categoryEntity = GetCategoryById(id);

            _context.Remove(categoryEntity);

            return _context.SaveChanges() > 0 ? true : false;
        }


    }
}
