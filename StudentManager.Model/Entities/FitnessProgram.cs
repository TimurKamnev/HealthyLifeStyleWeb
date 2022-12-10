using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class FitnessProgram
    {
        public int Id { get; set; }
        public virtual List<Training> Trainings { get; set; }
        public virtual List<FitnessTip> FitnessTips { get; set; }
        public virtual FitnessType FitnessType { get; set; }
        public int FitnessTypeId { get; set; }
    }
}
