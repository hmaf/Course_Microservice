
using Category.Domain.Entity;
using Category.Domain.Repositories;
using Category.Infrastractor.MongoDbDrive.Data;
using MongoDB.Driver;

namespace Category.Infrastractor.MongoDbDrive.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region constractor
        private readonly ICategoryContext _categoryContext;

        public CategoryRepository(ICategoryContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        #endregion

        #region Query
        public async Task<IEnumerable<CategoryModel>> GetCategories()
            => await _categoryContext.Categories.Find(o => true).ToListAsync();

        public async Task<CategoryModel> GetCategoryAsync(string id)
            => await _categoryContext.Categories.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task<CategoryModel> GetCategoryByTitileAsync(string title)
            => await _categoryContext.Categories.Find(c => c.Title == title).FirstOrDefaultAsync();

        #endregion

        #region Command
        public async Task CreateCategoryAsync(CategoryModel Category)
            => await _categoryContext.Categories.InsertOneAsync(Category);

        public async Task<bool> UpdateCategoryAsync(CategoryModel Category)
        {
            var updateResult = await _categoryContext.Categories
                .ReplaceOneAsync(filter: o => o.Id == Category.Id, replacement: Category);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            FilterDefinition<CategoryModel> filter =
                Builders<CategoryModel>.Filter.Eq(c => c.Id, id);

            DeleteResult deleteResult =
                await _categoryContext.Categories.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        #endregion

    }
}
