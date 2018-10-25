using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
     public class Patient
    {
        public int idPatient { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime birthDate { get; set; }
        public String adress { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public IEnumerator<> gender { get; set; }
    }
}
