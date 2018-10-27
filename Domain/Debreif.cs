using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Debreif
    {
        public int IdDebreif { get; set; }
        public String FinalDisease { get; set; }
        public String Description { get; set; }
        public virtual Appointment appointment { get; set; }
    }
}
