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
            /*  User u = new User { Email = "emel.garouachi@esprit.tn",
                 adress = "1 rue de sfax",
                 UserName="emel",
                 gender=Gender.
                 female,
                 lastName="Garouachi",
                 birthDate=DateTime.Now};*/
            Test t = new Test { TestId = 2, nom = "test" };
        ctx.Tests.Add(t);
           ctx.SaveChanges();
        }
    }
}
