using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

[Index(nameof(Name), IsUnique = true)]

internal class Contact
{
    public int ContactId { get; set; }
    
    public required string Name { get; set; } 
    public  required string Email { get; set; }
    public required string PhoneNumber { get; set; }

    public int CategoryId {get; set;}
    public Category Category {get; set;} = null!;

}

