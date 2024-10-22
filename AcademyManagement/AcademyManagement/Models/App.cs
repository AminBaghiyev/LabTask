namespace AcademyManagement.Models;

internal class App
{
    public static void CreateStudentPage(StudentService studentService)
    {
        Header("Student Form");

        Student student = new()
        {
            Id = StudentService.Counter
        };

        Console.Write("Enter student's first name: ");
        student.FirstName = Console.ReadLine();

        Console.Write("Enter student's last name: ");
        student.LastName = Console.ReadLine();

        Console.Write("Enter student's email: ");
        student.Email = Console.ReadLine();

        Console.Write("Enter student's phone number: ");
        student.PhoneNumber = Console.ReadLine();

        Console.Write("Enter student's GPA: ");
        double.TryParse(Console.ReadLine(), out double gpa);
        student.GPA = gpa;

        student.Status = ""; // for setter

        Console.Write("Enter student's major: ");
        student.Major = Console.ReadLine();

        studentService.CreateStudent(student);

        Console.Clear();
    }

    public static void GetAllStudentsPage(StudentService studentService)
    {
        foreach (Student student in studentService.GetAllStudents())
        {
            Header($"{student.Id} student");
            Console.WriteLine($"First name: {student.FirstName}");
            Console.WriteLine($"Last name: {student.LastName}");
        }

        FooterCommands();
    }

    #region Config App
    public static void Commands()
    {
        Console.WriteLine("[0] -> Create a student");
        Console.WriteLine("[1] -> Get a student by id");
        Console.WriteLine("[2] -> Get all students");

        ErrorMsg("[Q] -> Quit App");
    }

    public static void FooterCommands()
    {
        Console.WriteLine();
        Console.WriteLine("[M] -> Go to Main Page");
        ErrorMsg("[Q] -> Quit App");
        Console.WriteLine();

        InfinitInput(out string input, "There is no such command!", ["M", "Q"]);
        Console.Clear();

        switch (input)
        {
            case "M":
                return;

            case "Q":
                Environment.Exit(0);
                break;
        }
    }
    #endregion

    #region Source Code
    public static void Header(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"--- {message} ---");
        Console.ResetColor();
    }
    public static void Input(ref string input, bool isCommand = false)
    {
        Console.WriteLine();
        Console.Write("> ");
        input = isCommand ?
            Console.ReadLine().Trim().ToUpper() :
            Console.ReadLine().Trim();
    }
    public static void InfinitInput (out string input, string errorMsg, string[] exceptions, string placeholder = "> ")
    {
        while (true)
        {
            Console.Write(placeholder);
            input = Console.ReadLine().Trim();
            if (exceptions.Contains(input, StringComparer.CurrentCultureIgnoreCase)) break;
            if (errorMsg  != null) ErrorMsg(errorMsg);
        }
    }
    public static void ErrorMsg(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void WarningMsg(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void SuccessMsg(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    #endregion
}
