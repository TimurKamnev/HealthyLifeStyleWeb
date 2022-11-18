using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Person : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayData { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Gender Gender { get; set; }
        public bool IsAdmin { get; set; } = false;
        public enum Gender
        {
            Male,
            Female,
            Child
        }
    }
}
