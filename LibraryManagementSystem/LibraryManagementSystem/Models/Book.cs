namespace LibraryManagementSystem.Models;

internal class Book : LibraryItem
{
    public string Genre { get; set; }

    public Book(string Title, DateTime? PublicationYear) : base(Title, PublicationYear)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Publication year: {PublicationYear}");
    }
}
