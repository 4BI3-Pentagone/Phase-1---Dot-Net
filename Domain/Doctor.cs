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
    }
}
