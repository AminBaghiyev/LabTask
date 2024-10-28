using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Helpers;

internal static class LibraryHelper
{
    public static int CalculateAge(this LibraryItem item)
    {
        if (item.PublicationYear == null) { return -1; }

        return DateTime.Now.Year - item.PublicationYear.Value.Year;
    }

    public static string ToTitleCase(this LibraryItem item) => char.ToUpper(item.Title[0]) + item.Title[1..];
}