using Spectre.Console;
using PhoneBook.UI;

namespace PhoneBook;
internal class CategoryService
{
    internal static void InsertCategory()
    {
        var category = new Category();
        category.Name= AnsiConsole.Ask<string>("Nome da Categoria:");

        CategoryController.AddCategory(category);
    }

    internal static void GetCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }

   internal static Category GetCategoryOptionInput()
{
    var categories = CategoryController.GetCategories();
    var categoriesArray = categories.Select(x => x.Name).ToArray();
    var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Selecione uma categoria:")
            .AddChoices(categoriesArray));
            var category = categories.SingleOrDefault(x => x.Name == option)!;
    ;
    return category;
}

    internal static void GetCategory()
    {
        var category = GetCategoryOptionInput();
        UserInterface.ShowCategory(category);    
    }

   internal static void DeleteCategory()
{
    var category = GetCategoryOptionInput();
    CategoryController.DeleteCategory(category);
}

internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        var name = AnsiConsole.Ask<string>("Nome da Categoria:");

        category.Name = name;

        CategoryController.UpdateCategory(category);
    }

}