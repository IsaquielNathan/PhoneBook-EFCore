using Microsoft.EntityFrameworkCore;
using Spectre.Console; 
using PhoneBook;
using PhoneBook.Services;
 
namespace PhoneBook.UI;

internal class UserInterface

{
     static internal void ShowMenu()
     {
          var isAppRunning = true;
          while  (isAppRunning)

   { Console.Clear();
    var option = AnsiConsole.Prompt(
    new SelectionPrompt<MenuOptions>()
        .Title("Selecione uma opção:")
        .PageSize(7)
        .AddChoices(Enum.GetValues<MenuOptions>())
);
    switch (option)
    { 
        case MenuOptions.AddContact:
            ContactService.InsertContact();
            break;
    
        case MenuOptions.ViewContact:
            ContactService.GetProduct();
            break;
        
        case MenuOptions.ViewAllContacts:
            ContactService.GetContacts();
            break;

        case MenuOptions.RemoveContacts:
            ContactService.RemoveContacts();
            break;

        case MenuOptions.UpdateContact:
            ContactService.UpdateContact();
            break;

        case MenuOptions.AddCategory:
            CategoryService.InsertCategory();
            break;

        case MenuOptions.DeleteCategory:
            CategoryService.DeleteCategory();
            break;
        
        case MenuOptions.ViewCategory:
            CategoryService.GetCategory();
            break;

        case MenuOptions.ViewAllCategories:
            CategoryService.GetCategories();
            break;
           

        case MenuOptions.UpdateCategories:
            CategoryService.UpdateCategory();
            break;

        case MenuOptions.Sair:
            isAppRunning = false;
            Console.WriteLine("Saindo do programa...");
            break;
    }
}
     }
     static internal void ShowContact (Contact contact)
     {
          var panel = new Panel($@"Id: {contact.ContactId} Nome: {Spectre.Console.Markup.Escape(contact.Name)} Email: {Spectre.Console.Markup.Escape(contact.Email)} Número de Telefone: {Spectre.Console.Markup.Escape(contact.PhoneNumber)} Categoria: {Spectre.Console.Markup.Escape(contact.Category.Name)}" );
          panel.Header = new PanelHeader("Contact Info");
          panel.Padding = new Padding(2, 2, 2, 2);

          AnsiConsole.Write(panel);
          Console.WriteLine("Pressione enter para continuar");
          Console.ReadLine();
          Console.Clear(); 

     }
     static internal void ShowContactTable (List <Contact> contacts)
     {
      var table = new Table();
        table.AddColumn("[green]Id[/]");
        table.AddColumn("[green]Nome[/]");
        table.AddColumn("[green]Email[/]");
        table.AddColumn("[green]Número de telefone[/]");
        table.AddColumn("[green]Categoria[/]");


        foreach (var contact in contacts)
        {
         table.AddRow(
            contact.ContactId.ToString(), 
             Spectre.Console.Markup.Escape(contact.Name), 
            Spectre.Console.Markup.Escape(contact.Email), 
            Spectre.Console.Markup.Escape(contact.PhoneNumber),
             Spectre.Console.Markup.Escape(contact.Category!.Name)
            );
        }
        AnsiConsole.Write(table);
        Console.WriteLine("Pressione enter para continuar");
        Console.ReadLine();
        Console.Clear();   
     }
      static internal void ShowCategoryTable (List <Category> categories)
     {
      var table = new Table();
        table.AddColumn("[green]Id[/]");
        table.AddColumn("[green]Nome[/]");


        foreach (Category category in categories)
        {
         table.AddRow(
            category.CategoryId.ToString(), 
            category.Name
            );
        }
        AnsiConsole.Write(table);
        Console.WriteLine("Pressione enter para continuar");
        Console.ReadLine();
        Console.Clear(); 
        
     }
     static internal void ShowCategory (Category category)
     {
          var panel = new Panel($@"Id: {category.CategoryId} Categoria: {category.Name} Número de Contatos: {category.Contacts.Count}");
          panel.Header = new PanelHeader($"{category.Name}");
          panel.Padding = new Padding(2, 2, 2, 2);

          AnsiConsole.Write(panel);

          ShowContactTable(category.Contacts);

          Console.WriteLine("Pressione enter para continuar");
          Console.ReadLine();
          Console.Clear(); 

     }
}

