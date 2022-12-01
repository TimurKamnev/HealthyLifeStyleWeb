using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Person 
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
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
        public virtual Gender Gender { get; set; }
        public virtual List<Achievement> Achievements { get; set; }
        public bool IsAdmin { get; set; } = false;
        public virtual List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
