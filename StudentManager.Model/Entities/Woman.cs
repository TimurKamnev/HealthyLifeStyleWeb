using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Backend.Entities
{
    public class Woman : Person
    {
        public int MenstruationCycle { get; set; }
    }
}
