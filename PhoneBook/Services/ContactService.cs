using PhoneBook;
using PhoneBook.Controllers;
using PhoneBook.UI;
using Spectre.Console;

namespace PhoneBook.Services;

internal class ContactService
{   
    internal static void InsertContact()
    {
        var name = AnsiConsole.Ask<string>("Nome do Contato:");
        var email = AnsiConsole.Ask<string>("Email do Contato:");
        var phoneNumber = AnsiConsole.Ask<string>("Número do Contato:");
        var category = CategoryService.GetCategoryOptionInput();
            ContactController.AddContact(name, email, phoneNumber, category.CategoryId); 
    }

    internal static void GetContacts()
    {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactTable(contacts);
    }

    internal static  void RemoveContacts()
{
    var contact = GetContactOptionInput();

    if (contact != null)
    {
        ContactController.RemoveContacts(contact);
        
    }
    else
    {
        Console.WriteLine("Contato não encontrado!");
    }
}
    internal static void GetProduct()
    {
        var contatoSelecionado = GetContactOptionInput();
    if (contatoSelecionado != null)
    {
        UserInterface.ShowContact(contatoSelecionado);
    }
    }

    static private Contact? GetContactOptionInput()
    {
        
        var contacts = ContactController.GetContacts();
        if (!contacts.Any())
        
{
        AnsiConsole.MarkupLine("[yellow]Nenhum contato cadastrado![/]");
        return null;
}
        var contactsArray = contacts.Select(x =>Spectre.Console.Markup.Escape(x.Name));
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Selecione um contato: ")
                .AddChoices(contactsArray)
        );
        
        var id = contacts.Single(x => Spectre.Console.Markup.Escape(x.Name) == option).ContactId;
        var contact = ContactController.GetContactById(id);
        return contact;
    }

    internal static void UpdateContact()
    {
        var contact = GetContactOptionInput();
        if (contact == null)
    {
        return; 
    }
    contact.Name = AnsiConsole.Confirm("Deseja alterar o nome?") ? 
        AnsiConsole.Ask<string>("Novo Nome:") : contact.Name;

    contact.Email = AnsiConsole.Confirm("Deseja alterar o email?") ? 
        AnsiConsole.Ask<string>("Novo Email:") : contact.Email;

    contact.PhoneNumber = AnsiConsole.Confirm("Deseja alterar o número?") ? 
        AnsiConsole.Ask<string>("Novo Número:") : contact.PhoneNumber;

    contact.Category = AnsiConsole.Confirm("Atualizar Categoria ?:") ?
        CategoryService.GetCategoryOptionInput() : contact.Category;


        ContactController.UpdateContact(contact);
    }
}