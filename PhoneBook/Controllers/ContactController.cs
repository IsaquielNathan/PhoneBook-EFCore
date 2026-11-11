using Spectre.Console;
using PhoneBook;
using Microsoft.EntityFrameworkCore;




namespace PhoneBook.Controllers;
internal class ContactController
{
    public static void AddContact(string name, string email, string phoneNumber, int? categoryId)
    {
        using var db = new ContactContext();
        db.Add(new Contact { 
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber,
            CategoryId = categoryId
            });
            db.SaveChanges();   
    }
    public static void UpdateContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Update (contact);
        db.SaveChanges();

    }
    public static List<Contact> GetContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts
        .Include(x => x.Category)
        .ToList();
        return contacts;
    }
    public static void RemoveContacts(Contact contact)
    {
        using var db = new ContactContext();
         db.Remove(contact);
         db.SaveChanges();
    }
    

    public static Contact? GetContactById(int id)
    {
      using var db = new ContactContext();
      var contact = db.Contacts
      .Include(x => x.Category)
      .SingleOrDefault(x => x.ContactId == id);
    return contact  ;
    }

    public static bool ContactExists(string name)
{
    using var db = new ContactContext();
    return db.Contacts.Any(c => c.Name.ToLower() == name.ToLower());
}

   
}
   