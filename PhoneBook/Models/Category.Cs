using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook;
internal class Category
{
    public int CategoryId { get; set; }
    
    [Column("CategoryName")] 
     public string Name { get; set; } = null!;

    public List<Contact> Contacts { get; set; } = new();
}