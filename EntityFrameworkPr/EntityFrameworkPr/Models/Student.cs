namespace EntityFrameworkPr.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public bool IsSoftDeleted { get; set; }
}
