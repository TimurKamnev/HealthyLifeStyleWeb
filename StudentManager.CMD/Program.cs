using StudentManager.Backend.Entiries;
using StudentManager.Backend.Entities;
using StudentManager.Controller.Controllers;

namespace EskholFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentController studentController = new StudentController();

            var a = studentController.GetAllStudents();
            Console.WriteLine();
            //Console.WriteLine("Welcome to the club, buddy!");
            //Console.WriteLine("Enter count of students:");



            //var studentsCount = int.Parse(Console.ReadLine());

            //StudentController studentController = new StudentController();
            //SkillController skillController = new SkillController();

            //var skills = skillController.GetAllSkills();

            //foreach(Skill skill in skills)
            //{
            //    Console.WriteLine(skill);
            //}

            //Console.WriteLine("Please start filling your fucking students data");

            //for (var i = 0; i < studentsCount; i++)
            //{
            //    Console.WriteLine("Please enter its name and age in separate strings");
            //    var name = Console.ReadLine();
            //    var age = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Enter skill Id");

            //    var skillId = int.Parse(Console.ReadLine());

            //    Skill skill = skillController.GetSkillById(skillId);
            //    Skill sleepingSkill = skillController.GetSkillById(5);
            //    var skillList = new List<Skill>() { skill, sleepingSkill };

            //    var student = new Student(name, age);
            //    studentController.AddStudentWithSkills(student, skillList);
            //}
        }
    }
}