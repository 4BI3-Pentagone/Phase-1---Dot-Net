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
        public virtual ICollection<Step> steps { get; set; }
       


    }
}
