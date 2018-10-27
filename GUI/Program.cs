using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data;

namespace GUI
{
    class Program
    {

        static void Main(string[] args)
        {
            PiContext ctx = new PiContext();
            Patient p = new Patient()
            {
                PatientId = 12
               


            };
            ctx.Patients.Add(p);
            ctx.SaveChanges();

        }
    }
}
