namespace EmployeeAbstractClass.Models;

internal abstract class Employee
{
    private static int counter;
    protected int Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public byte Age { get; set; }

    protected Employee()
    {
        Id = counter;
        counter++;
    }

    public abstract double CalculateSalary();

    public abstract void DisplayDetails();
}
