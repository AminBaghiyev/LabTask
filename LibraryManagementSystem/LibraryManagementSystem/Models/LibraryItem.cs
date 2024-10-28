namespace LibraryManagementSystem.Models;

internal abstract class LibraryItem
{
    private static int _counter = 0;
    public int Id { get; }

    protected LibraryItem(string Title, DateTime? PublicationYear)
    {
        Id = _counter;
        _counter++;
    }

    public string Title { get; set; }
    public DateTime? PublicationYear { get; set; }

    public abstract void DisplayInfo();
}
