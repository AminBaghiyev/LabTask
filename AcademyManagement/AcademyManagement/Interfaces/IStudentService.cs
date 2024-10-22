using AcademyManagement.Models;

namespace AcademyManagement.Interfaces;

internal interface IStudentService
{
    Student GetStudentById(int id);
    Student[] GetAllStudents();
    Student[] GetStudentsByName();
    void CreateStudent(Student student);
    void UpdateStudent(int id);
    void RemoveStudent(int id, bool isSoftDelete);
}
