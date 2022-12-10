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
        public virtual FitnessType FitnessType { get; set; }
        public int FitnessTypeId { get; set; }
        public bool IsCurrent { get; set; }
    }
}
