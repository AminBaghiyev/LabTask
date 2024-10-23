using AcademyManagement.Models;

namespace AcademyManagement.Interfaces;

internal interface IStudentService
{
    (Student? student, int index) GetStudentById(int id);
    Student[] GetAllStudents();
    Student[] GetStudentsByName(string name);
    void CreateStudent(Student student);
    bool UpdateStudent(int id);
    bool RemoveStudent(int id, bool isSoftDelete);
}
