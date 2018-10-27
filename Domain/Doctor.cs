using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Speciality { Generalist , Specialist}
    public class Doctor
    {
        public int idDoctor { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime birthDate { get; set; }
        public String adress { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Gender gender { get; set; }
        public Speciality speciality { get; set; }
    }
}
