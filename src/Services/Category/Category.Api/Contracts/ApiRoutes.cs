using Category.Application.Dtos.Category;

namespace Category.Api.Contracts
{
    public static class ApiRoutes
    {
        public static class Category
        {
            public const string CreateCategory = "api/Category/";
            public const string UpdateCategory = "api/Category/";
            public const string GetCategories = "api/Category/";
            public const string GetCategoryByTitle = "api/Category/{Title}";
            public const string GetCategoryById = "api/Category/{CategoryId}";
            public const string DeleteCategory = "api/Category/{CategoryId}";
        }

    }
}
