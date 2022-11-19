using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class PersonFitnessProgram
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }

        public bool IsCurrent { get; set; }
    }
}
