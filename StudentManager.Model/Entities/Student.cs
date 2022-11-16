using StudentManager.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entiries
{
    public class Student : BaseEntity
    {
        public int Age { get; set; }
        public virtual List<StudentsSkills> StudentsSkills { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public List<Skill> GetSkills()
        {
            return StudentsSkills.Select(sk => sk.Skill).ToList();
        }

        public Student(){
            StudentsSkills = new List<StudentsSkills>();
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
