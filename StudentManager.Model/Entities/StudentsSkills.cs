using StudentManager.Backend.Entiries;

namespace StudentManager.Backend.Entities
{
    public class StudentsSkills
    {
        public int StudentId { get; set; }
        public int SkillId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
