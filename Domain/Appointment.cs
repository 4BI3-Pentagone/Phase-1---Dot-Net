using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum State { Done, InProgress , Cancelled }
    public  class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public String Disease { get; set; }
        public State state { get; set; }
        public virtual Patient patient { get; set; }
        public virtual Doctor doctor { get; set; }
      //  public virtual Course course { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
