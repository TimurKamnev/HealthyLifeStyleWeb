using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public string PersonId { get; set; }
        public virtual List<Training> Trainings { get; set; }
        [Required]
        public int? Period { get; set; }
    }
}
