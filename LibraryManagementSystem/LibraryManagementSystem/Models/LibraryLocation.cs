using LibraryManagementSystem.Enums;

namespace LibraryManagementSystem.Models;

internal struct LibraryLocation
{
    public BookGenre Genre { get; set; }
    public int Aisle { get; set; }
    public int Shelf { get; set; }
}
