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

   internal static Category? GetCategoryOptionInput()
{
     var categories = CategoryController.GetCategories();
      
      if (!categories.Any())
    {
        AnsiConsole.MarkupLine("[yellow]Nenhuma categoria cadastrada! Crie uma categoria primeiro.[/]");
        Console.WriteLine("Pressione enter para continuar");
        Console.ReadLine();
        return null;
    } 
    var categoriesArray = categories.Select(x =>Spectre.Console.Markup.Escape (x.Name)).ToArray();
    var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Selecione uma categoria:")
            .AddChoices(categoriesArray));
            var category = categories.SingleOrDefault(x =>Spectre.Console.Markup.Escape (x.Name) == option)!;
    ;
    return category;
}

    internal static void GetCategory()
    {
        var category = GetCategoryOptionInput();
         if (category == null)
    {
        return; 
    }
        UserInterface.ShowCategory(category);    
    }

   internal static void DeleteCategory()
{
    var category = GetCategoryOptionInput();
     if (category == null)
    {
        return; 
    }
    CategoryController.DeleteCategory(category);
}

internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();
         if (category == null)
    {
        return; 
    }

        var name = AnsiConsole.Ask<string>("Nome da Categoria:");

        category.Name = name;

        CategoryController.UpdateCategory(category);
    }

}