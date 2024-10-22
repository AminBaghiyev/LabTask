namespace AcademyManagement.Models;

internal class Student
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double GPA { get; set; }
    private string _status;
    public string Status
    {
        get { return _status; }
        set
        {
            do
            {
                if (value.ToLower() == "active" || value.ToLower() == "graduate" || value.ToLower() == "pending" || value.ToLower() == "removed")
                {
                    _status = value;
                    break;
                }
                Console.WriteLine("Enter student status (active, graduate, pending, removed): ");
                value = Console.ReadLine();
            }
            while (true);
        }
    }
    public string Major { get; set; }
}
