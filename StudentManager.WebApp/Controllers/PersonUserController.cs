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

        public void AddUser(CreatedUser user, double weight, double height, string firstName, string lastName,DateTime dateTime, Gender gender)
        {
            var shortenUser = MapUser(user);
            ExpandUserObject(shortenUser, weight, height, firstName, lastName, dateTime, gender);
            _dbContext.Person.Add(shortenUser);

            _dbContext.SaveChanges();
        }

        private void ExpandUserObject(Person user, double weight, double height, string firstName, string lastName,DateTime dateTime,Gender gender)
        {
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Gender = gender;
            user.Weight = weight;
            user.Height = height;
            user.BirthdayDate = dateTime;
        }

        private Person MapUser(CreatedUser mozgoeb)
        {
            return new Person()
            {
                Id = mozgoeb.Id,
                
            };
        }
    }
}
