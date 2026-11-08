using Microsoft.EntityFrameworkCore;

internal class ContactConxtet : DbContext

{
    public DbSet<Contact> Contacts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseSqlite($"Data Source = contact.db");
}