using EmployeeAbstractClass.Models;

namespace EmployeeAbstractClass;

internal class Program
{
    static void Main(string[] args)
    {
        #region Hourly Employee section
        HourlyEmployee hourlyEmployee = new();

        Console.Write("Enter name: ");
        hourlyEmployee.Name = Console.ReadLine();

        Console.Write("Enter surname: ");
        hourlyEmployee.Surname = Console.ReadLine();

        Console.Write("Enter age: ");
        byte.TryParse(Console.ReadLine(), out byte age);
        hourlyEmployee.Age = age;

        Console.Write("Enter hourly rate: ");
        int.TryParse(Console.ReadLine(), out int hourlyRate);
        hourlyEmployee.HourlyRate = hourlyRate;

        Console.Write("Enter hours worked: ");
        int.TryParse(Console.ReadLine(), out int hoursWorked);
        hourlyEmployee.HoursWorked = hoursWorked;

        hourlyEmployee.DisplayDetails();
        #endregion

        Console.WriteLine("\n--------------------------------------\n");

        #region Salaried Employee section
        SalariedEmployee salariedEmployee = new();

        Console.Write("Enter name: ");
        salariedEmployee.Name = Console.ReadLine();

        Console.Write("Enter surname: ");
        salariedEmployee.Surname = Console.ReadLine();

        Console.Write("Enter age: ");
        byte.TryParse(Console.ReadLine(), out age);
        salariedEmployee.Age = age;

        Console.Write("Enter monthly salary: ");
        int.TryParse(Console.ReadLine(), out int monthlySalary);
        salariedEmployee.MonthlySalary = monthlySalary;

        salariedEmployee.DisplayDetails();
        #endregion
    }
}
