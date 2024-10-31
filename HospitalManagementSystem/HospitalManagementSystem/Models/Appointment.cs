namespace HospitalManagementSystem.Models;

internal class Appointment
{
    private static int _counter = 0;

    private readonly int _id;

    public int Id { get { return _id; } }

    public string PatientName { get; set; }

    public string DoctorName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Appointment()
    {
        _id = _counter++;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Patient name: {PatientName}");
        Console.WriteLine($"Doctor name: {DoctorName}");
        Console.WriteLine($"Start date: {StartDate}");
        Console.WriteLine($"End date: {EndDate}");
    }
}
