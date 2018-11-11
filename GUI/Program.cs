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
            Course c = new Course {
            };

            Patient u = new Patient { Email = "emhi@eaaaa.tn",
              adress = "1 rue de sfax",
              UserName="emel",
              PasswordHash="sameh",
              lastName="Garouachi",
              birthDate=DateTime.Now,
              course=c };
            //    ctx.Users.Add(u);
            //   ctx.SaveChanges();
            //  c.steps
            //  SC.Add(c);
            ctx.Courses.Add(c);
            ctx.Users.Add(u);


            ctx.SaveChanges();
           
        }
    }
}
