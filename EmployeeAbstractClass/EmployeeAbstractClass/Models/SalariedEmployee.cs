namespace EmployeeAbstractClass.Models;

internal class SalariedEmployee : Employee
{
    public double MonthlySalary { get; set; }

    public override double CalculateSalary() => MonthlySalary;

    public override void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Surname: {Surname}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Monthly salary: {MonthlySalary}");
        Console.WriteLine($"Salary: {CalculateSalary()}");
    }
}
