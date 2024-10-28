namespace LibraryManagementSystem.Models;

internal class LibraryCatalog
{
    public Book[] Catalog { get; set; }

    public LibraryCatalog()
    {
        Catalog = [];
    }

    public Book? this[int id]
    {
        get
        {
            for (int i = 0; i < Catalog.Length; i++)
            {
                if (Catalog[i].Id == id) return Catalog[i];
            }
            return null;
        }
    }
}
