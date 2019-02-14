namespace KeepHome.Common
{
    public static class GlobalConstants
    {
        public const string AdminRoleName = "Admin";
        public const string UserRoleName = "User";

        public const int UserCountCheckForAdmin = 1;

        public const string CANNOT_DELETE_CATEGORY_IF_ANY_CHILD_CATEGORY = "Може да изтриете основна категория само ако не съдържа други категории!";
        public const string CANNOT_DELETE_CATEGORY_IF_ANY_PRODUCTS = "Може да изтриете категория само ако не съдържа продукти!";

        public const int NextPageValue = 1;
        public const int MaxElementsOnPage = 27;

        public const string BlogAreaName = "Blog";
        public const string TitleNameInBG = "Заглавие";
        public const string ContentNameInBG = "Съдържание";

        public const string ErrorViewName = "Error";
    }
}