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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Debreif> Debreifs { get; set; }
        public DbSet<Repport> Repports { get; set; }
        public DbSet<Rate> Rates { get; set; }
     public DbSet<Step> Steps { get; set; }
        public DbSet<Question> Quetions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SubComment> SubComments { get; set; }
        public virtual DbSet<CategoriePost> CategoriePosts { get; set; }



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
<<<<<<< HEAD


            CategoriePost cp = new CategoriePost();
            cp.Libelle = "Denatire";
            cp.Description="Dentaire";
            context.CategoriePosts.Add(cp);


            CategoriePost cp2 = new CategoriePost();
            cp.Libelle = "Cardio";
            cp.Description = "Cardio";
            context.CategoriePosts.Add(cp2);

            CategoriePost cp3 = new CategoriePost();
            cp.Libelle = "Esthetique";
            cp.Description = "Esthetique";
            context.CategoriePosts.Add(cp2);

            CategoriePost cp4 = new CategoriePost();
            cp.Libelle = "Esthetique";
            cp.Description = "Esthetique";
            context.CategoriePosts.Add(cp4);


            CategoriePost cp5 = new CategoriePost();
            cp.Libelle = "gynecologi.";
            cp.Description = "gynecologie.";
            context.CategoriePosts.Add(cp4);


            CategoriePost cp6 = new CategoriePost();
            cp.Libelle = "pediatrie";
            cp.Description = "pediatrie";
            context.CategoriePosts.Add(cp6);

            CategoriePost cp7 = new CategoriePost();
            cp.Libelle = "neurologie";
            cp.Description = "neurologie";
            context.CategoriePosts.Add(cp6);

=======
           // context.SaveChanges();
       
        List<  Appointment>appointments = new List<Appointment>() {
                new Appointment {state =State.Done},
                new Appointment {state =State.Done},
                new Appointment {state =State.Done},
                  new Appointment {state =State.Done},
                    new Appointment {state =State.Done},
                      new Appointment {state =State.Done},
                      new Appointment {state =State.Done},
                        new Appointment {state =State.Done}

            };
            context.Appointments.AddRange(appointments);
>>>>>>> 22b02e64d51a80a21f57cb838d3d3f0e4910b095
            context.SaveChanges();
        }

    }
}
