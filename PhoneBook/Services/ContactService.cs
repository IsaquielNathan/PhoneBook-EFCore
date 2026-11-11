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
        if (ContactController.ContactExists(name))
{
        AnsiConsole.MarkupLine("[red]Operação cancelada: Já existe um contato com esse nome no banco de dados.[/]");
        Console.WriteLine("Pressione enter para voltar ao menu...");
        Console.ReadLine();
        return; 
};

        var email = AnsiConsole.Prompt(
            new TextPrompt<string>("Email do Contato:")
            .Validate(e => e.Contains("@") && e.Contains(".")
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]E-mail inválido! O e-mail deve conter '@' e um domínio'.'[/]"))
);
        var phoneNumber = AnsiConsole.Prompt(
            new TextPrompt<string>("Número do Contato: ")
            .Validate(numero => numero.Length == 11 && numero.All(char.IsDigit)
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Formato inválido! Digite o número sem traços ou espaços.[/]"))
        );

        var category = CategoryService.GetCategoryOptionInput();
        int? categoryId = category?.CategoryId;
        ContactController.AddContact(name, email, phoneNumber, categoryId);
        AnsiConsole.MarkupLine("[green]Contato adicionado com sucesso![/]");
    }

    internal static void GetContacts()
    {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactTable(contacts);
    }

    internal static void RemoveContacts()
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
    internal static void GetContact()
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
            Console.WriteLine("Pressione enter para voltar ao menu...");
            Console.ReadLine();

            return null;
        }
        var contactsArray = contacts.Select(x => Spectre.Console.Markup.Escape(x.Name));
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