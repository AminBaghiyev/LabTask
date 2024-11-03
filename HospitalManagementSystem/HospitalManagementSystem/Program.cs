using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        App app = new();
        App.WarningMessage("Welcome to the Hospital Management System!");
        string input = "";

        while (true)
        {
            App.CommandSection();
            input = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (input)
                {
                    case "1":
                        app.CreateAppointment();
                        break;

                    case "2":
                        app.EndAppointment();
                        break;

                    case "3":
                        app.SeeAllAppointments();
                        break;

                    case "4":
                        app.SeeThisWeeksAppointments();
                        break;

                    case "5":
                        app.SeeTodaysAppointments();
                        break;

                    case "6":
                        app.SeePendingAppointments();
                        break;

                    case "7":
                        app.SeeAppointmentsByDateRange();
                        break;

                    case "0":
                        return;

                    default:
                        throw new NoValidCommandException();
                }
            }
            catch (Exception ex)
            {
                App.ErrorMessage(ex.Message);
            }
        }
    }
}
