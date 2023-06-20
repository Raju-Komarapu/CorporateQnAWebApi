using AutoMapper;
using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Data.Models.Category.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;

namespace CorporateQnA.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            var categoryList = this._db.GetAll<CategoryDetailsView>();
            return this._mapper.Map<IEnumerable<CategoryListItem>>(categoryList);
        }

        public Guid AddCategory(Category newCategory)
        {
            var category = this._mapper.Map<CorporateQnA.Data.Models.Category.Category>(newCategory);
            var sqlQuery = "INSERT INTO Category (Title, Description) OUTPUT INSERTED.Id VALUES (@title, @description)";
            var parameters = new { title = category.Title, description = category.Description };
            return this._db.ExecuteScalar<Guid>(sqlQuery, parameters);
        }

        public CategoryListItem GetCategory(Guid id)
        {
            var category = this._db.Get<CategoryDetailsView>(id);
            return this._mapper.Map<CategoryListItem>(category);
        }
    }
}
