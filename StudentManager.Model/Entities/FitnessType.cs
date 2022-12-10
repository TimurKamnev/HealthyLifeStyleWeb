using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class FitnessType
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual FitnessProgram FitnessProgram { get; set; }
        public virtual List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
