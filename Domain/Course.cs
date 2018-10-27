using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
        public int IdCourse { get; set; }
        public ICollection<Appointment> Visits { get; set; }

    }
}
