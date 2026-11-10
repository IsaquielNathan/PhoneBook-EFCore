using Microsoft.EntityFrameworkCore;

namespace PhoneBook;


internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ContactContext();

        db.Add(category);
        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ContactContext();
        var categories = db.Categories
        .Include(c => c.Contacts)
        .ToList();
        return categories;
    }
     public static void DeleteCategory(Category category)
    {
        using var db = new ContactContext();
         db.Remove(category);
         db.SaveChanges();
    }
    public static void UpdateCategory(Category category)
    {
        using var db = new ContactContext();
        db.Update (category);
        db.SaveChanges();

    }
}