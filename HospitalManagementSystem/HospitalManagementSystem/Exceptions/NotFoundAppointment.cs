namespace HospitalManagementSystem.Exceptions;

public class NotFoundAppointment : Exception
{
    public NotFoundAppointment() : base("Appointment not found!") { }
    public NotFoundAppointment(string message) : base(message) { }
}
