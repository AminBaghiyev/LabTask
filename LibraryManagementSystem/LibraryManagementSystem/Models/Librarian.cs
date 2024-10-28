namespace LibraryManagementSystem.Models;

internal class Librarian : Person
{
    public DateTime HireDate { get; set; }
    public Librarian(string Name) : base(Name)
    {
    }
}
