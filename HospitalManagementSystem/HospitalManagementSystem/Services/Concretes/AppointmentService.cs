using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services.Interfaces;

namespace HospitalManagementSystem.Services.Concretes;

internal class AppointmentService : IAppointmentService
{
    private List<Appointment> _appointments;

    public AppointmentService()
    {
        _appointments = [];
    }

    public void AddAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }

    public void EndAppointment(int id)
    {
        Appointment appointment = GetAppointment(id);
        appointment.EndDate = DateTime.Now;
    }

    public List<Appointment> GetAllAppointments() => _appointments;

    public List<Appointment> GetAllContinuingAppointments()
    {
        List<Appointment> continuingAppointments = [];
        foreach (var appointment in _appointments)
        {
            if (appointment.EndDate == null) continuingAppointments.Add(appointment);
        }
        return continuingAppointments;
    }

    public Appointment GetAppointment(int id)
    {
        foreach (var appointment in _appointments)
        {
            if (appointment.Id == id) return appointment;
        }
        throw new NotFoundAppointment();
    }

    public List<Appointment> GetTodaysAppointments()
    {
        List<Appointment> todaysAppointments = [];
        foreach (var appointment in _appointments)
        {
            if (
                DateTime.Now.Year == appointment.StartDate.Year &&
                DateTime.Now.DayOfYear == appointment.StartDate.DayOfYear
                )
            {
                todaysAppointments.Add(appointment);
            }
        }
        return todaysAppointments;
    }

    public List<Appointment> GetWeeklyAppointments()
    {
        List<Appointment> weeklyAppointments = [];
        TimeSpan diff = TimeSpan.Zero;
        foreach (var appointment in _appointments)
        {
            diff = DateTime.Now - appointment.StartDate;
            if (diff.Days <= 7)
            {
                weeklyAppointments.Add(appointment);
            }
        }
        return weeklyAppointments;
    }
}
