using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entiries;

namespace StudentManager.Backend.Controllers
{
    public class StudentController
    {
        public void AddStudent(Student student)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                ctx.Students.Add(student);

                ctx.SaveChanges();
            }
        }

        public List<Student> GetAllStudents()
        {
            using AppDbContext ctx = new AppDbContext();

            var students = ctx.Students.ToList();

            return students;

        }
    }

}
