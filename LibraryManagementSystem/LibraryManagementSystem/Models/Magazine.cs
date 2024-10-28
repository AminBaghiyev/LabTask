namespace LibraryManagementSystem.Models;

internal class Magazine : LibraryItem
{
    public Magazine(string Title, DateTime? PublicationYear) : base(Title, PublicationYear)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Publication year: {PublicationYear}");
    }
}
