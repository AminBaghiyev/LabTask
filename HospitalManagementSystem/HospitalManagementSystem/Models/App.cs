using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Services.Concretes;

namespace HospitalManagementSystem.Models;
internal class App
{
    private AppointmentService _appointmentService { get; set; }

    public App()
    {
        _appointmentService = new AppointmentService();
    }

    #region Components
    public static void CommandSection()
    {
        HeaderMessage("Commands");
        Console.WriteLine("1 -> Create a Appointment");
        Console.WriteLine("2 -> End a Appointment");
        Console.WriteLine("3 -> See all appointments");
        Console.WriteLine("4 -> See this week's appointments");
        Console.WriteLine("5 -> See today's appointments");
        Console.WriteLine("6 -> See pending appointments");
        Console.WriteLine("7 -> See appointments within a specific date range");
        ErrorMessage("0 -> Quit App");
        Console.WriteLine();
    }

    public static void FooterSection()
    {
        Console.WriteLine("\n1 -> To go to the home page");
        ErrorMessage("0 -> Quit App\n");
        string input = InfiniteInput(["1", "0"], errorMessage: "Enter the right commands!");
        Console.Clear();

        switch (input)
        {
            case "1":
                return;

            case "0":
                Environment.Exit(0);
                break;
        }
    }

    public void CreateAppointment()
    {
        HeaderMessage("Add Appointment");

        Appointment appointment = new Appointment();

        Console.Write("Enter patient's name: ");
        appointment.PatientName = Console.ReadLine();

        Console.Write("Enter doctor's name: ");
        appointment.DoctorName = Console.ReadLine();

        Console.Write("Enter start date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
        appointment.StartDate = startDate;

        _appointmentService.AddAppointment(appointment);

        Console.Clear();
        SuccessMessage("Appointment added successfully.\n");
    }

    public void EndAppointment()
    {
        HeaderMessage("End Appointment");

        int id = -1;
        Console.Write("Enter appointment id: ");
        int.TryParse(Console.ReadLine(), out id);

        if (id == -1) throw new NotFoundAppointment();

        _appointmentService.EndAppointment(id);

        Console.Clear();
        SuccessMessage("Appointment ended successfully.\n");
    }

    public void SeeAllAppointments()
    {
        List<Appointment> appointments = _appointmentService.GetAllAppointments();

        if (appointments.Count == 0) throw new NotFoundAppointment();

        HeaderMessage("All Appointments");

        foreach (var appointment in appointments)
        {
            Console.WriteLine();
            appointment.DisplayInfo();
        }

        FooterSection();
    }

    public void SeeThisWeeksAppointments()
    {
        List<Appointment> appointments = _appointmentService.GetWeeklyAppointments();

        if (appointments.Count == 0) throw new NotFoundAppointment();

        HeaderMessage("This Week's Appointments");

        foreach (var appointment in appointments)
        {
            Console.WriteLine();
            appointment.DisplayInfo();
        }

        FooterSection();
    }

    public void SeeTodaysAppointments()
    {
        List<Appointment> appointments = _appointmentService.GetTodaysAppointments();

        if (appointments.Count == 0) throw new NotFoundAppointment();

        HeaderMessage("Today's Appointments");

        foreach (var appointment in appointments)
        {
            Console.WriteLine();
            appointment.DisplayInfo();
        }

        FooterSection();
    }

    public void SeePendingAppointments()
    {
        List<Appointment> appointments = _appointmentService.GetAllContinuingAppointments();

        if (appointments.Count == 0) throw new NotFoundAppointment();

        HeaderMessage("Pending Appointments");

        foreach (var appointment in appointments)
        {
            Console.WriteLine();
            appointment.DisplayInfo();
        }

        FooterSection();
    }

    public void SeeAppointmentsByDateRange()
    {
        HeaderMessage("Appointments By Date Range");

        Console.Write("Start date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
        Console.Write("End date (format: \"dd.MM.yyyy\"): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
        Console.Clear();

        List<Appointment> appointments = _appointmentService.GetAppointmentsByDateRange(startDate, endDate);

        if (appointments.Count == 0) throw new NotFoundAppointment();

        HeaderMessage($"{startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy} Appointments");

        foreach (var appointment in appointments)
        {
            Console.WriteLine();
            appointment.DisplayInfo();
        }

        FooterSection();
    }
    #endregion

    #region Source Code
    public static string InfiniteInput(string[] expected, string message = "", string errorMessage = "", bool isUpper = false)
    {
        string input = "";
        while (true)
        {
            Console.Write(message);
            input = isUpper ?
                Console.ReadLine().Trim().ToUpper() :
                Console.ReadLine().Trim();
            if (expected.Contains(input)) { break; }
            if (errorMessage.Trim().Length > 0) { ErrorMessage(errorMessage); }
        }

        return input;
    }

    public static void HeaderMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"--- {message} ---");
        Console.ResetColor();
    }

    public static void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    #endregion
}