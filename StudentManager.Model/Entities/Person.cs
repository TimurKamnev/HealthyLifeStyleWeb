using System.ComponentModel.DataAnnotations;

namespace StudentManager.Backend.Entities
{
    public class Person 
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
        public virtual Gender Gender { get; set; }
        public bool IsAdmin { get; set; } = false;
        public virtual List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
