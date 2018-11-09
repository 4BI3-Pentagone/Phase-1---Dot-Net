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
using Data.Configurations;

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
   //     public DbSet<User> Users{ get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Debreif> Debreifs { get; set; }
        public DbSet<Repport> Repports { get; set; }
        public DbSet<Rate> Rates { get; set; }
     public DbSet<Step> Steps { get; set; }



        public static PiContext Create()
        {
            return new PiContext();
        }

     /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfig());
        }*/

    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
            Patient p = new Patient();
            p.Email = "ah@gmail.com";
            p.PasswordHash = "123456789";
            p.UserName = "ah";
            context.Users.Add(p);
            context.SaveChanges();
        }
    }
}
