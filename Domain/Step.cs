using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Step
    {
        public int StepId { get; set; }
        public virtual Course course { get; set; }
        public String treatment { get; set; }
        public State state  { get; set; }
        public virtual Appointment visit { get; set; }
    }
}
