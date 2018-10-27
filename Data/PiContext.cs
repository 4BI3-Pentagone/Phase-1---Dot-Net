using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PiContext : DbContext
    {
        public PiContext() : base("PIDB")
        {
            Database.SetInitializer(new ContexInit());
         }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors{ get; set; }



    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
            List<Patient> patients = new List<Patient>() {
                new Patient {idPatient=1,
                adress="ddd"

                }
               
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
    }
}
