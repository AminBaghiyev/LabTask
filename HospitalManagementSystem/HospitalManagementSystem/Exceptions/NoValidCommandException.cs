namespace HospitalManagementSystem.Exceptions;

public class NoValidCommandException : Exception
{
    public NoValidCommandException() : base("There is no such command!") {}
    public NoValidCommandException(string message) : base(message) {}
}
