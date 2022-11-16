using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entities;
using StudentManager.Backend.Repositories;

namespace StudentManager.Controller.Controllers
{
    public class SkillController
    {
        private IRepository<Skill> _skillRepository;

        public SkillController()
        {
            AppDbContext ctx = new AppDbContext();
            _skillRepository = new DbRepository<Skill>(ctx);
        }
        
        public Skill AddSkill(Skill skill)
        {
            return _skillRepository.Create(skill);
        }

        public List<Skill> GetAllSkills()
        {
            return _skillRepository.ReadAll();
        }

        public Skill GetSkillById(int id)
        {
            return _skillRepository.ReadById(id);
        }
    }

}
