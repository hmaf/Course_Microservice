

using ErrorOr;

namespace Category.Application.Core.ApplicationError
{
    public static class ValidationError
    {
        public static class CreateCategory
        {
            public static string Title_Is_Required =>
                "CreateCategory.Title_Is_Required"
                + "," +
                "عنوان نمیتواند خالی باشد";

            public static string Title_Length_Is_Not_Valid =>
                "CreateCategory.Title_Length_Is_Not_Valid"
                + "," +
                "طول عنوان نمیتواند کوتاه تر از 3 و بزرگتر از 50 کاراکتر باشد";

            public static string ShorDescription_Is_Required =>
                "CreateCategory.ShorDescription_Is_Required"
                + "," +
                "توضیحات کوتاه نمیتواند خالی باشد";

            public static string ShorDescription_Is_Cannot_Less_Length =>
                "CreateCategory.ShorDescription_Is_Cannot_less_Length"
                + "," +
                "توضیحات کوتاه نمیتواند کوتاهتر از 15 کاراکتر باشد";

            public static string ShorDescription_Length_Is_Cannot_Greater_Than =>
                "CreateCategory.ShorDescription_Length_Is_Cannot_Greater_Than"
                + "," +
                "توضیحات کوتاه نمیتواند بزرگتر از 155 کاراکتر باشد";
        }

        public static class UpdateCategory
        {
            public static string ID_Is_Required =>
                "CreateCategory.Id_Is_Required"
                + "," +
                "شناسه دسته بندی را پر کنید";

            public static string Title_Is_Required =>
                "CreateCategory.Title_Is_Required"
                + "," +
                "عنوان نمیتواند خالی باشد";

            public static string Title_Length_Is_Not_Valid =>
                "CreateCategory.Title_Length_Is_Not_Valid"
                + "," +
                "طول عنوان نمیتواند کوتاه تر از 3 و بزرگتر از 50 کاراکتر باشد";

            public static string ShorDescription_Is_Required =>
                "CreateCategory.ShorDescription_Is_Required"
                + "," +
                "توضیحات کوتاه نمیتواند خالی باشد";

            public static string ShorDescription_Is_Cannot_Less_Length =>
                "CreateCategory.ShorDescription_Is_Cannot_less_Length"
                + "," +
                "توضیحات کوتاه نمیتواند کوتاهتر از 15 کاراکتر باشد";

            public static string ShorDescription_Length_Is_Cannot_Greater_Than =>
                "CreateCategory.ShorDescription_Length_Is_Cannot_Greater_Than"
                + "," +
                "توضیحات کوتاه نمیتواند بزرگتر از 155 کاراکتر باشد";
        }

        public static class DeleteCategory
        {
            public static string ID_Is_Required =>
                "CreateCategory.Id_Is_Required"
                + "," +
                "شناسه دسته بندی را پر کنید";
        }
    }
}
