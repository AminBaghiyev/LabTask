using AcademyManagement.Interfaces;
using AcademyManagement.Enums;

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

    public (Student? student, int index) GetStudentById(int id)
    {
        for (int i = 0; i < students.Length; i++)
            if (students[i].Id == id) return (students[i], i);
        
        return (null, -1);
    }

    public Student[] GetStudentsByName(string name)
    {
        Student[] students = [];

        foreach (Student student in this.students)
        {
            if (student.FirstName == name)
            {
                Array.Resize(ref students, students.Length + 1);
                students[^1] = student;
            }
        }

        return students;
    }

    public bool RemoveStudent(int id, bool isSoftDelete = true)
    {
        (Student? student, int index) = GetStudentById(id);

        if (student == null) return false;

        if (isSoftDelete) students[index].Status = StudentStatus.Removed;
        else
        {
            Student[] updatedStudents = new Student[students.Length - 1];
            int counter = 0;

            foreach (Student std in students)
                if (std.Id != id) updatedStudents[counter++] = std;

            students = updatedStudents;
        }

        return true;
    }

    public bool UpdateStudent(int id)
    {
        (Student? student, int index) = GetStudentById(id);

        if (student == null) return false;

        App.StudentForm(ref student);

        students[index] = student;

        return true;
    }
}
