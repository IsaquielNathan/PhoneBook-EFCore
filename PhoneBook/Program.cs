using Spectre.Console;




var isAppRunning = true;
while (isAppRunning)
    var option = AnsiConsole.Prompt(
    new SelectionPrompt<ContactOptions>()
        .Title("Selecione uma opção:")
        .AddChoices(Enum.GetValues<ContactOptions>())
);
    switch (option)
    {
        case ContactOptions.AddContact:
            ContactController.AddContact();
            break;
        case ContactOptions.ViewContacts:
            ContactController.ViewContacts();
            break;
        case ContactOptions.UpdateContact:
            ContactController.UpdateContact();
            break;
        case ContactOptions.ViewAllContacts:
            ContactController.ViewAllContacts();
            break;
        case ContactOptions.RemoveContacts:
            ContactController.RemoveContacts();
            break;
        case ContactOptions.Sair:
            isAppRunning = false;
            Console.WriteLine("Saindo do programa...");
            break;
    }

   

        enum ContactOptions { 
            AddContact, 
            ViewContacts, 
            UpdateContact, 
            ViewAllContacts,
            RemoveContacts, 
            Sair }

    