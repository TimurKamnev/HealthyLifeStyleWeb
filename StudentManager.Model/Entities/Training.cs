using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Training
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
        [Required]
        public int Duration { get; set; }
        public virtual FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
