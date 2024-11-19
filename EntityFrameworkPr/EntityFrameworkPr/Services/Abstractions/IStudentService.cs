using EntityFrameworkPr.Models;

namespace EntityFrameworkPr.Services.Abstractions;

public interface IStudentService
{
    void CreateStudent(Student student);
    Student GetStudentById(int id);
    List<Student> GetStudentsByName(string name);
    List<Student> GetAllStudents();
    List<Student> GetAllActiveStudents();
    List<Student> GetStudentsByEnrollmentDate(int days);
    void UpdateStudent(int id, Student student);
    void HardDeleteStudent(int id);
    void SoftDeleteStudent(int id);
}
