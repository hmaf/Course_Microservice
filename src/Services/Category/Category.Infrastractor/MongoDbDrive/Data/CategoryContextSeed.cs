using Category.Domain.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Infrastractor.MongoDbDrive.Data
{
    public class CategoryContextSeed
    {
        public static void SeedData(IMongoCollection<CategoryModel> categoryModelCollection)
        {
            bool existCategories = categoryModelCollection.Find(p => true).Any();

            if (!existCategories)
            {
                categoryModelCollection.InsertManyAsync(GetSeedData());
            }
        }   

        private static IEnumerable<CategoryModel> GetSeedData()
        {
            var category = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = BsonObjectId.GenerateNewId().ToString(),
                    CreateDate = DateTime.Now,
                    CreatedBy = "",
                    Icon = "NoIcon.npg",
                    Title = "Where does it come from?",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                },
                new CategoryModel()
                {
                    Id = BsonObjectId.GenerateNewId().ToString(),
                    CreateDate = DateTime.Now,
                    CreatedBy = "",
                    Icon = "NoIcon.npg",
                    Title = "Where does it come from?",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                },
                new CategoryModel()
                {
                    Id = BsonObjectId.GenerateNewId().ToString(),
                    CreateDate = DateTime.Now,
                    CreatedBy = "",
                    Icon = "NoIcon.npg",
                    Title = "Where does it come from?",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                }
            };

            return category;
        }
            
    }

}
