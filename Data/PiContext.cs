using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySql.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
 //   [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PiContext : IdentityDbContext<User>
    {
        
        public PiContext() : base("Name=PIDB")
        {
            Database.SetInitializer(new ContexInit());
         }

        //  public DbSet<Patient> Patients { get; set; }
        //  public DbSet<Doctor> Doctors{ get; set; }
#pragma warning disable CS0114 // Un membre masque un membre hérité ; le mot clé override est manquant
        public DbSet<User> Users{ get; set; }
#pragma warning restore CS0114 // Un membre masque un membre hérité ; le mot clé override est manquant

        public DbSet<Course> Courses { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Debreif> Debreifs { get; set; }
        public DbSet<Repport> Repports { get; set; }
        public DbSet<Rate> Rates { get; set; }




        public static PiContext Create()
        {
            return new PiContext();
        }



    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
         /*   List<Patient> patients = new List<Patient>() {
                new Patient {PatientId=1
                            }
               
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();*/
        }
    }
}
