using Microsoft.EntityFrameworkCore;

internal class Contact
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public  required string Email { get; set; }
    public required string PhoneNumber { get; set; }

}

