using Fitness.Infrastracture;
using StudentManager.Backend.Entities;
using StudentManager.WebApp.Areas;
using StudentManager.WebApp.Areas.Identity;
using StudentManager.WebApp.Areas.Identity.Data;

namespace StudentManager.WebApp.Controllers
{
    public class PersonUserController : IShortedUserController
    {
        private readonly AppDbContext _dbContext;

        public PersonUserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(Person user, double weight, double height, string firstName, string lastName,DateTime dateTime, Gender gender)
        {
            var shortenUser = MapUser(user);
            ExpandUserObject(shortenUser, weight, height, firstName, lastName, dateTime, gender);
            _dbContext.Person.Add(shortenUser);

            _dbContext.SaveChanges();
        }

        private void ExpandUserObject(Person user, double weight, double height, string firstName, string lastName,DateTime dateTime,Gender gender)
        {
            throw new NotImplementedException();
        }

        private Person MapUser(Person mozgoeb)
        {
            return new Person()
            {
                Id = mozgoeb.Id,
                FirstName = mozgoeb.FirstName,
                LastName = mozgoeb.LastName,
                Weight = mozgoeb.Weight,
                Height = mozgoeb.Height,
                BirthdayDate = mozgoeb.BirthdayDate,
                Gender = mozgoeb.Gender
            };
        }
    }
}
