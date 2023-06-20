using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace CorporateQnA.Api.Controllers
{
    [Route("api/category")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryServices;

        public CategoryController(ICategoryService categoryServices)
        {
            this._categoryServices = categoryServices;
        }

        [HttpPost]
        public Guid AddCategory(Category newCategory)
        {
            return this._categoryServices.AddCategory(newCategory);
        }

        [HttpGet("all")]
        public IEnumerable<CategoryListItem> GetCategoryList()
        {
            return this._categoryServices.GetAllCategories();
        }

        [HttpGet("{id}")]
        public CategoryListItem GetCategory(Guid id)
        {
            return this._categoryServices.GetCategory(id);
        }
    }
}
