using StudentManager.Backend.Entiries;

namespace StudentManager.Backend.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
             
        }
        public Skill(string name, SkillLevel level)
        {
            Name = name;
            Level = level;
        }
        public SkillLevel Level { get; set; }
        public virtual List<StudentsSkills> StudentsSkills { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Level}";
        }
    }

    public enum SkillLevel
    {
        Common,
        Rare,
        Epic,
        Mythic,
        Legendary,
    }
}
