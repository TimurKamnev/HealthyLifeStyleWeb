using StudentManager.Backend.Entiries;

namespace StudentManager.Backend.Entities
{
    public class Skill
    {
        public Skill()
        {
             
        }
        public Skill(string name, SkillLevel level)
        {
            Name = name;
            Level = level;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public SkillLevel Level { get; set; }
        public List<Student> Students { get; set; }

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
