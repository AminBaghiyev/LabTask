using AcademyManagement.Enums;

namespace AcademyManagement.Models;

internal class Student
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double GPA { get; set; }
    private StudentStatus _status;
    public StudentStatus? Status
    {
        get { return _status; }
        set
        {
            string input = value.ToString();
            do
            {
                if (Enum.TryParse(input, true, out StudentStatus result))
                {
                    _status = result;
                    break;
                }
                Console.Write("Enter student status (active, graduate, pending, removed): ");
                input = Console.ReadLine();
            }
            while (true);
        }
    }
    public string Major { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"First name: {FirstName}");
        Console.WriteLine($"Last name: {LastName}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone number: {PhoneNumber}");
        Console.WriteLine($"GPA: {GPA}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Major: {Major}");
    }
}
