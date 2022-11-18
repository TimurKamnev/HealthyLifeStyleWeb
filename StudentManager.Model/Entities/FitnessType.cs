using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class FitnessType
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
