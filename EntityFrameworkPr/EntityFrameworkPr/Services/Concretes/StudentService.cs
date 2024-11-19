using EntityFrameworkPr.Contexts;
using EntityFrameworkPr.Models;
using EntityFrameworkPr.Services.Abstractions;

namespace EntityFrameworkPr.Services.Concretes;

internal class StudentService : IStudentService
{
    public void CreateStudent(Student student)
    {
        ApplicationDbContext db = new();

        db.students.Add(student);

        db.SaveChanges();
    }

    public List<Student> GetAllActiveStudents()
    {
        ApplicationDbContext db = new();
        List<Student> students = db.students.Where(
            student => !student.IsSoftDeleted)
            .ToList();

        return students;
    }

    public List<Student> GetAllStudents()
    {
        ApplicationDbContext db = new();

        return db.students.ToList();
    }

    public Student GetStudentById(int id)
    {
        ApplicationDbContext db = new();

        return db.students.Find(id);
    }

    public List<Student> GetStudentsByEnrollmentDate(int days)
    {
        ApplicationDbContext db = new();

        DateTime startDate = DateTime.Now.AddDays(-days);
        DateTime endDate = DateTime.Now;

        List<Student> students = db.students.Where(
            student => startDate <= student.EnrollmentDate && endDate >= student.EnrollmentDate)
            .ToList();

        return students;
    }

    public List<Student> GetStudentsByName(string name)
    {
        ApplicationDbContext db = new();
        List<Student> students = db.students.Where(
            student => student.FirstName == name)
            .ToList();

        return students;
    }

    public void HardDeleteStudent(int id)
    {
        ApplicationDbContext db = new();

        Student student = db.students.Find(id) ?? throw new Exception("Student not found!");

        db.students.Remove(student);
        db.SaveChanges();
    }

    public void SoftDeleteStudent(int id)
    {
        ApplicationDbContext db = new();

        Student student = db.students.Find(id) ?? throw new Exception("Student not found!");
        student.IsSoftDeleted = true;

        db.students.Update(student);
        db.SaveChanges();
    }

    public void UpdateStudent(int id, Student student)
    {
        ApplicationDbContext db = new();

        if (student.Id != id) throw new Exception("IDs do not match");

        db.students.Update(student);
        db.SaveChanges();
    }
}
