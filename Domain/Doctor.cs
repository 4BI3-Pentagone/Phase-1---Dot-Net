using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Speciality { Generalist , Specialist}
    public class Doctor : User
    {

        public Speciality speciality { get; set; }

     //   public virtual ICollection<Course> Courses { get; set; }
        //public virtual ICollection<Chat> Conversations { get; set; }
       // public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
