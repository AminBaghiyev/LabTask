using EntityFrameworkPr.Models;
using EntityFrameworkPr.Services.Abstractions;
using EntityFrameworkPr.Services.Concretes;

namespace EntityFrameworkPr;

internal class Program
{
    static void Main(string[] args)
    {
        Student std1 = new();

        IStudentService stdService = new StudentService();

        //stdService.CreateStudent(std1);

        foreach (var std in stdService.GetStudentsByEnrollmentDate(2000))
        {
            std1 = std;
            Console.WriteLine($"{std.Id} | {std.FirstName} | {std.LastName}");
        }

        std1.Password = "123455";
        stdService.UpdateStudent(1, std1);

        //Console.WriteLine(stdService.GetStudentById(2).FirstName);
    }
}
