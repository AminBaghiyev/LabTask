namespace AcademyManagement.Models;

internal class App
{
    #region Components
    public static void StudentForm(ref Student student)
    {
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

        student.Status = null; // for setter

        Console.Write("Enter student's major: ");
        student.Major = Console.ReadLine();
    }

    public static void CreateStudentPage(StudentService studentService)
    {
        Header("Student Form");

        Student student = new()
        {
            Id = StudentService.Counter
        };

        StudentForm(ref student);

        studentService.CreateStudent(student);

        Console.Clear();

        SuccessMsg("Student created successfully");
    }

    public static void GetStudentByIdPage(StudentService studentService)
    {
        Header("Find Student By Id");

        Console.Write("Enter student's id: ");
        int.TryParse(Console.ReadLine(), out int id);
        (Student? student, _) = studentService.GetStudentById(id);
        Console.WriteLine();

        if (student != null) student.ShowInfo();
        else WarningMsg("No student with this id was found.");

        FooterCommands();
    }

    public static void GetAllStudentsPage(StudentService studentService)
    {
        Header("All Students");
        Student[] response = studentService.GetAllStudents();

        if (response.Length > 0)
            foreach (Student student in response)
            {
                Console.WriteLine();
                Header($"{student.Id} student");
                student.ShowInfo();
            }
        else WarningMsg("No students found.");

        FooterCommands();
    }

    public static void GetStudentsByNamePage(StudentService studentService)
    {
        Header("Search Students By Name");

        Console.Write("Enter students' name: ");
        string input = Console.ReadLine();

        Student[] response = studentService.GetStudentsByName(input);

        if (response.Length > 0)
            foreach (Student student in response)
            {
                Console.WriteLine();
                Header($"{student.Id} student");
                student.ShowInfo();
            }
        else WarningMsg("No student with this name was found.");

        FooterCommands();
    }

    public static void UpdateStudentPage(StudentService studentService)
    {
        Header("Update a Student");

        Console.Write("Enter student's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        bool response = studentService.UpdateStudent(id);
        Console.Clear();

        if (response) SuccessMsg("Student info updated successfully.");
        else WarningMsg("No student with this id was found.");
    }

    public static void RemoveStudentPage(StudentService studentService)
    {
        Header("Remove a Student");

        Console.Write("Enter student's id: ");
        int.TryParse(Console.ReadLine(), out int id);

        bool isSoftDelete = true;
        Console.Write("Soft delete (true or false): ");
        bool.TryParse(Console.ReadLine(), out isSoftDelete);

        bool response = studentService.RemoveStudent(id, isSoftDelete);
        Console.Clear();

        if (response) SuccessMsg("Student removed successfully.");
        else WarningMsg("No student with this id was found.");
    }
    #endregion

    #region Config App
    public static void Commands()
    {
        Console.WriteLine("[0] -> Create a student");
        Console.WriteLine("[1] -> Get a student by id");
        Console.WriteLine("[2] -> Get all students");
        Console.WriteLine("[3] -> Get students by name");
        Console.WriteLine("[4] -> Update a student");
        Console.WriteLine("[5] -> Remove a student");

        ErrorMsg("[Q] -> Quit App");
    }

    public static void FooterCommands()
    {
        Console.WriteLine();
        Console.WriteLine("[M] -> Go to Main Page");
        ErrorMsg("[Q] -> Quit App");
        Console.WriteLine();

        InfinitInput(out string input, "There is no such command!", ["M", "Q" ], true);
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
    public static void InfinitInput(out string input, string errorMsg, string[] exceptions, bool ignoreCase, string placeholder = "> ")
    {
        while (true)
        {
            Console.Write(placeholder);
            input = ignoreCase ?
                Console.ReadLine().Trim().ToUpper() :
                Console.ReadLine().Trim();
            if (exceptions.Contains(input)) break;
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
