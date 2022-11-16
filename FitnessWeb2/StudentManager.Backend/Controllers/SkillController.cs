using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Controllers
{
    public class SkillController
    {
        public void AddSkill(Skill skill)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                ctx.Skills.Add(skill);

                ctx.SaveChanges();
            }
        }

        public List<Skill> GetAllSkills()
        {
            using AppDbContext ctx = new AppDbContext();

            var skill = ctx.Skills.ToList();

            return skill;
        }

        public Skill GetSkillById(int id)
        {
            using AppDbContext ctx = new AppDbContext();

            var skill = ctx.Skills.FirstOrDefault(sk => sk.Id == id);

            return skill;
        }
    }

}
