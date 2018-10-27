using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Rate
    {
        public int RateId { get; set; }
        public float Note { get; set; }
        public virtual Patient patient { get; set; }
        public virtual Appointment appointment { get; set; }
    }
}
