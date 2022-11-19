using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Person : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        public Gender Gender { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool IsAdmin { get; set; } = false;
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Child
    }
}
