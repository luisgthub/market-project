using CoreBusiness;
using UseCases.PluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository :ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category {CategoryId=1, Name="Bebidas",Description="todo tipo de bebidas"},
                new Category {CategoryId=2, Name="Frios",Description="todo o tipo de frios"},

            };
        }
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
        public void AddCategory(Category category) { 
           if (categories.Any(x=>x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null) categoryToUpdate = category;
        }
        
        public Category GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void DeleteCategory(int categoryId) => categories?.Remove(GetCategoryById(categoryId));
    }
}