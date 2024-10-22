using AcademyManagement.Models;

namespace AcademyManagement;

internal class Program
{
    static void Main(string[] args)
    {
        App.WarningMsg("Welcome to the Academy Management System!");
        StudentService studentService = new();
        string input = "";

        while (true)
        {
            App.Header("Commands");
            App.Commands();
            App.Input(ref input, true);
            Console.Clear();

            switch (input)
            {
                case "Q":
                    return;

                case "0":
                    App.CreateStudentPage(studentService);
                    break;
                
                case "2":
                    App.GetAllStudentsPage(studentService);
                    break;

                default:
                    App.ErrorMsg("There is no such command!");
                    break;
            }
        }
    }
}
