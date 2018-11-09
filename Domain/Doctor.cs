using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //public enum Speciality {
    //    Cardiologist,
    //    Dentist,
    //    Dermatologist,
    //    Gastroenterologist,
    //    General,
    //    Gynecologist,
    //    Pediatrician,
    //    Therapist
    //}
    public class Doctor : User
    {

        public virtual Speciality Speciality { get; set; }
        [ForeignKey("Speciality")]
        public int? SpecialityId { get; set; }
        //   public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Chat> Conversations { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
