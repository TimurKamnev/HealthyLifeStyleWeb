using StudentManager.Backend.Entities;
using StudentManager.WebApp.Areas.Identity.Data;

namespace StudentManager.WebApp.Areas
{
    public interface IShortedUserController
    {
        public void AddUser(Person user, double weight,double height, string firstName, string lastName, DateTime dateTime, Gender gender);
    }
}
