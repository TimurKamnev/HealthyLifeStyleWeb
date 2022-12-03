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
        public virtual Person Person { get; set; }
        public string PersonId { get; set; }
        public virtual FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }

        public bool IsCurrent { get; set; }
    }
}
