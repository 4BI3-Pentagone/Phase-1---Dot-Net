using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    //public enum Speciality
    //{
    //    Cardiologist,
    //    Dentist,
    //    Dermatologist,
    //    Gastroenterologist,
    //    General,
    //    Gynecologist,
    //    Pediatrician,
    //    Therapist
    //}

    public class DoctorModel:User
    {

        //   public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Chat> Conversations { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public int? SpecialityId { get; set; }
        public virtual Speciality speciality { get; set; }

        // public IEnumerable<SelectListItem> categories { get; set; }

        public IEnumerable<SelectListItem> Specialities { get; set; }
    }
}