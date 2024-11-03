using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Services.Interfaces;

internal interface IAppointmentService
{
    void AddAppointment(Appointment appointment);
    void EndAppointment(int id);
    Appointment GetAppointment(int id);
    List<Appointment> GetAllAppointments();
    List<Appointment> GetWeeklyAppointments();
    List<Appointment> GetTodaysAppointments();
    List<Appointment> GetAllContinuingAppointments();
    List<Appointment> GetAppointmentsByDateRange(DateTime start, DateTime end);
}
