using Amazon.Runtime.Internal;
using Category.Domain.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Infrastractor.MongoDbDrive.Data
{
    public class CategoryContext : ICategoryContext
    {
        public IMongoCollection<CategoryModel> Categories { get; }

        public CategoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);
            Categories = database.GetCollection<CategoryModel>(configuration.GetSection("DatabaseSettings:CollectionName").Value);
            CategoryContextSeed.SeedData(Categories);
        }
    }
}
