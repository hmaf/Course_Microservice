using Category.Domain.Entity;
using MongoDB.Driver;



namespace Category.Infrastractor.MongoDbDrive.Data
{
    public interface ICategoryContext
    {
        IMongoCollection<CategoryModel> Categories { get; } 
    }
}
