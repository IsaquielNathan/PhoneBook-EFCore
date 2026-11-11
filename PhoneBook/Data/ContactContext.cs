using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

internal class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=Database/contact.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
    .HasOne(c => c.Category)
    .WithMany(c => c.Contacts)
    .HasForeignKey(c => c.CategoryId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Category>().HasData(
        new Category { CategoryId = 1, Name = "Família" },
        new Category { CategoryId = 2, Name = "Trabalho" }
    );

    modelBuilder.Entity<Contact>().HasData(
        new Contact { ContactId = 1, Name = "Administrador", Email = "admin@empresa.com", PhoneNumber = "000000000", CategoryId = 2 }
    );
    }
}