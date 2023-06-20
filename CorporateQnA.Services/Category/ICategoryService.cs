using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryListItem> GetAllCategories();

        Guid AddCategory(Category newCategory);

        CategoryListItem GetCategory(Guid id);
    }
}
