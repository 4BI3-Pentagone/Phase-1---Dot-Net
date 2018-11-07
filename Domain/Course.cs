using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public ICollection<Appointment> Visits { get; set; }
     //   public virtual Patient patient { get; set; }


    }
}
