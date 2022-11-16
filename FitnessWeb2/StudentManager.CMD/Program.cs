using StudentManager.Backend.Controllers;
using StudentManager.Backend.Entiries;
using StudentManager.Backend.Entities;

namespace EskholFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the club, buddy!");
            Console.WriteLine("Enter count of students:");

            var studentsCount = int.Parse(Console.ReadLine());

            StudentController studentController = new StudentController();
            SkillController skillController = new SkillController();

            var skills = skillController.GetAllSkills();

            foreach(Skill skill in skills)
            {
                Console.WriteLine(skill);
            }

            Console.WriteLine("Please start filling your fucking students data");

            for (var i = 0; i < studentsCount; i++)
            {
                Console.WriteLine("Please enter its name and age in separate strings");
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter skill Id");

                var skillId = int.Parse(Console.ReadLine());

                Skill skill = skillController.GetSkillById(skillId);
                Skill sleepingSkill = skillController.GetSkillById(5);
                var skillList = new List<Skill>() { skill, sleepingSkill };

                var student = new Student(name, age, skillList);
                studentController.AddStudent(student);
            }

            //Console.WriteLine("This is a student list");

            //List<Student> strudents = studentController.GetAllStudents();

            //foreach(var student in strudents)
            //{
            //    Console.WriteLine(student);
            //}



        }
    }
}