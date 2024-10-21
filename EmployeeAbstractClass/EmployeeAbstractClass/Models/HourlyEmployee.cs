namespace EmployeeAbstractClass.Models;

internal class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public override double CalculateSalary() => HourlyRate * HoursWorked;

    public override void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Surname: {Surname}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Hourly rate: {HourlyRate}");
        Console.WriteLine($"Hours worked: {HoursWorked}");
        Console.WriteLine($"Salary: {CalculateSalary()}");
    }
}
