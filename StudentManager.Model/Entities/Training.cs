using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Exercise> Exercise { get; set; }
        public int Duration { get; set; }
        public FitnessProgram FintessProgram { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
