namespace LibraryManagementSystem.Models;

internal sealed class LibraryMember : Person
{
    public DateTime MembershipDate { get; set; }

    public LibraryMember(string Name) : base(Name)
    {
    }
}
