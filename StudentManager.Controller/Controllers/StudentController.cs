using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entiries;
using StudentManager.Backend.Entities;
using StudentManager.Backend.Repositories;

namespace StudentManager.Controller.Controllers
{
    public class StudentController
    {
        private IRepository<Student> _studentRepository;

        public StudentController()
        {
            AppDbContext context = new AppDbContext();
            _studentRepository = new DbRepository<Student>(context);
        }

        public Student AddStudent(Student student)
        {
            return _studentRepository.Create(student);
        }

        public Student UpdateStudent(Student student)
        {
            return _studentRepository.Update(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.ReadAll();
        }

        public void AddStudentWithSkills(Student student, List<Skill> skills)
        {
            student = _studentRepository.Create(student);

            foreach (var skill in skills)
            {
                student.StudentsSkills.Add(
                    new StudentsSkills
                    {
                        Student = student,
                        Skill = skill
                    }
                    );
            }

            _studentRepository.Update(student);
        }
    }

}
