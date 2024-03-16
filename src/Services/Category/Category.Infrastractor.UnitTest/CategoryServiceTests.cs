using Category.Domain.Entity;
using Category.Infrastractor.MongoDbDrive.Data;
using Category.Infrastractor.MongoDbDrive.Repositories;
using MongoDB.Driver;
using Moq;

namespace Category.Infrastractor.UnitTest
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var categoryContextMock = new Mock<ICategoryContext>();
            var categories = GetSeedData();

            var mockCursor = new Mock<IAsyncCursor<CategoryModel>>();
            mockCursor.Setup(x => x.Current).Returns(categories);
            mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(true)
                .ReturnsAsync(false); // Ensure MoveNextAsync returns false after processing all items

            var categoryCollectionMock = new Mock<IMongoCollection<CategoryModel>>();
            categoryCollectionMock.Setup(x => x.FindAsync(It.IsAny<FilterDefinition<CategoryModel>>(), It.IsAny<FindOptions<CategoryModel, CategoryModel>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockCursor.Object);

            categoryContextMock.Setup(c => c.Categories)
                .Returns(categoryCollectionMock.Object);

            var categoryRepository = new CategoryRepository(categoryContextMock.Object);

            // Act
            var result = await categoryRepository.GetCategories();

            // Assert
            Assert.Equal(categories.Count(), result.Count());
        }

        [Fact]
        public async Task GetCategoryAsync_ShouldReturnCategoryById()
        {
            // Arrange
            var categoryId = "65d3651bff97d546c7418414";
            var categoryContextMock = new Mock<ICategoryContext>();
            var category = GetSeedData();

            var mockCursor = new Mock<IAsyncCursor<CategoryModel>>();
            //mockCursor.Setup(x => x.Current).Returns(new List<CategoryModel> { category });
            mockCursor.Setup(x => x.Current).Returns(category);
            mockCursor.Setup(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var categoryCollectionMock = new Mock<IMongoCollection<CategoryModel>>();
            categoryCollectionMock.Setup(x => x.FindAsync(It.IsAny<FilterDefinition<CategoryModel>>(), It.IsAny<FindOptions<CategoryModel, CategoryModel>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockCursor.Object);

            categoryContextMock.Setup(c => c.Categories)
                .Returns(categoryCollectionMock.Object);

            var categoryRepository = new CategoryRepository(categoryContextMock.Object);

            // Act
            var result = await categoryRepository.GetCategoryAsync(categoryId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(categoryId, result.Id);
        }

        [Fact]
        public async Task CreateCategoryAsync_ShouldInsertCategory()
        {
            // Arrange
            var categoryContextMock = new Mock<ICategoryContext>();
            categoryContextMock.Setup(x => x.Categories).Returns(Mock.Of<IMongoCollection<CategoryModel>>());

            var categoryRepository = new CategoryRepository(categoryContextMock.Object);
            var categoryModel = AddModel();

            // Ensure categoryContextMock is not null
            Assert.NotNull(categoryContextMock.Object);

            // Ensure Categories property in categoryContextMock is not null
            Assert.NotNull(categoryContextMock.Object.Categories);

            // Act
            await categoryRepository.CreateCategoryAsync(categoryModel);

            // Assert
            categoryContextMock.Verify(
            x => x.Categories.InsertOneAsync(It.IsAny<CategoryModel>(), null, default),
            Times.Once);

        }

        [Fact]
        public async Task CreateCategoryAsyncs_ShouldInsertCategory()
        {
            // Arrange
            var mockContext = new Mock<ICategoryContext>();
            var mockCollection = new Mock<IMongoCollection<CategoryModel>>();
            var categoryToInsert = AddModel();

            mockCollection.Setup(c => c.InsertOneAsync(categoryToInsert, It.IsAny<InsertOneOptions>(), default))
                          .Returns(Task.CompletedTask);
            mockContext.Setup(c => c.Categories).Returns(mockCollection.Object);

            var repository = new CategoryRepository(mockContext.Object);

            // Act
            await repository.CreateCategoryAsync(categoryToInsert);

            // Assert
            mockCollection.Verify(c => c.InsertOneAsync(categoryToInsert, It.IsAny<InsertOneOptions>(), default), Times.Once);
            // Add more specific assertions based on your requirements
        }

        [Fact]
        public async Task UpdateCategoryAsync_ShouldInsertCategory()
        {
            // Arrange
            var updatedCategory = new CategoryModel
            {
                Id = "65f04648bb8fc5cb1cec3b6d", // Existing category ID
                Title = "Updated Category Title",
                // Other properties to update as needed
            };

            var categoryContextMock = new Mock<ICategoryContext>();
            var categoriesCollectionMock = new Mock<IMongoCollection<CategoryModel>>();

            // Mocking the ReplaceOneAsync method to simulate a successful update
            categoriesCollectionMock.Setup(x => x.ReplaceOneAsync(
                It.IsAny<FilterDefinition<CategoryModel>>(),
                updatedCategory,
                It.IsAny<ReplaceOptions>(),
                default(CancellationToken)
            )).ReturnsAsync(new ReplaceOneResult.Acknowledged(1, 1, null)); // Simulating a successful update

            categoryContextMock.Setup(x => x.Categories).Returns(categoriesCollectionMock.Object);

            var categoryService = new CategoryRepository(categoryContextMock.Object);

            // Act
            var result = await categoryService.UpdateCategoryAsync(updatedCategory);

            // Assert
            Assert.True(result, "Update operation should be successful");
        }

        private CategoryModel AddModel()
            => new CategoryModel()
            {
                Id = "65f04648bb8fc5cb1cec3b6d",
                CreateDate = DateTime.Now,
                CreatedBy = "",
                Icon = "NoIcon.npg",
                Title = "Where does it come from?",
                LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
            };

        private static IEnumerable<CategoryModel> GetSeedData()
        {
            var category = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = "65d3651bff97d546c7418414",
                    CreateDate = DateTime.Now,
                    CreatedBy = "",
                    Icon = "NoIcon.npg",
                    Title = "Where does it come from?",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                },
                new CategoryModel()
                {
                    Id = "65f04648bb8fc5cb1cec3b6d",
                    CreateDate = DateTime.Now,
                    CreatedBy = "",
                    Icon = "NoIcon.npg",
                    Title = "Where does it come to?",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ShorDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text."
                },
                new CategoryModel()
                {
                    Id = "65d3816eff97d546c7418415",
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