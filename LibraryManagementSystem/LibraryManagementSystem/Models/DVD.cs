namespace LibraryManagementSystem.Models;

internal class DVD : LibraryItem
{
    public DVD(string Title, DateTime? PublicationYear) : base(Title, PublicationYear)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Publication year: {PublicationYear}");
    }
}
