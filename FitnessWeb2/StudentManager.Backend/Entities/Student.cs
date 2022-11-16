using StudentManager.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entiries
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Skill> Skills { get; set; }
        public Student(string name, int age, List<Skill> skills)
        {
            Name = name;
            Age = age;
            Skills = skills;
        }

        public Student()
        {

        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
