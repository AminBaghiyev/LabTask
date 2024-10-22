using AcademyManagement.Interfaces;

namespace AcademyManagement.Models;

internal class StudentService : IStudentService
{
    private static int _counter { get; set; }
    public static int Counter { get { return _counter; } }

    public Student[] students = [];

    public void CreateStudent(Student student)
    {
        _counter++;
        Array.Resize(ref students, students.Length + 1);
        students[^1] = student;
    }

    public Student[] GetAllStudents() => students;

    public Student GetStudentById(int id)
    {
        throw new NotImplementedException();
    }

    public Student[] GetStudentsByName()
    {
        throw new NotImplementedException();
    }

    public void RemoveStudent(int id, bool isSoftDelete)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(int id)
    {
        throw new NotImplementedException();
    }
}
