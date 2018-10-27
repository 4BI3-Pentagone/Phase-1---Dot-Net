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
        public PiContext() : base("Name=PIDB")
        {
            Database.SetInitializer(new ContexInit());
         }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Debreif> Debreifs { get; set; }
        public DbSet<Repport> Repports { get; set; }
        public DbSet<Rate> Rates { get; set; }








    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
            List<Patient> patients = new List<Patient>() {
                new Patient {PatientId=1
                            }
               
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
    }
}
