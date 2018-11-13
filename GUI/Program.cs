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

            /*     Patient u = new Patient { Email = "emhi@eaaaa.tn",
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
                 ctx.Users.Add(u);*/


            /*   List<Appointment> appointments = new List<Appointment>() {
                   new Appointment {state =State.Done ,Date=DateTime.Now},
                   new Appointment {state =State.Done,Date=DateTime.Now},
                   new Appointment {state =State.Done,Date=DateTime.Now},
                     new Appointment {state =State.Done,Date=DateTime.Now},
                       new Appointment {state =State.Done,Date=DateTime.Now},
                         new Appointment {state =State.Done,Date=DateTime.Now},
                         new Appointment {state =State.Done,Date=DateTime.Now},
                           new Appointment {state =State.Done,Date=DateTime.Now}

               };
               ctx.Appointments.AddRange(appointments);
               ctx.SaveChanges();*/
            try
            {
                pdfcrowd.HtmlToPdfClient client = new pdfcrowd.HtmlToPdfClient(
                "EmelGarouachi", "e0d5f339cf1166528742148593718537");

            // run the conversion and write the result to a file
            client.convertUrlToFile("http://localhost:54774/Pat/Index", "example.pdf");
            }
            catch (pdfcrowd.Error why)
            {
                // report the error
                System.Console.Error.WriteLine("Pdfcrowd Error: " + why);

                // handle the exception here or rethrow and handle it at a higher level
               // throw;
            }


        }
    }
}
