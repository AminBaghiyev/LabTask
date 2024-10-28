namespace LibraryManagementSystem.Helpers;

internal class CustomBookError : Exception
{
    public CustomBookError() : base("The book with the entered id is not in the catalogue!")
    {

    }
    public CustomBookError(string message) : base(message)
    {

    }
}
