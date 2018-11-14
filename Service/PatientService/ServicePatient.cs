using Data;
using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
{
    public class ServicePatient : Service<Patient>, IServicePatient
<<<<<<< HEAD
         
=======

>>>>>>> 3bba1ba9699804c5097019f601711d2d51f211e7
    {



        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        PiContext pc;

<<<<<<< HEAD
       
=======
        
>>>>>>> 3bba1ba9699804c5097019f601711d2d51f211e7
        public ServicePatient() : base(UOW)
        {
          //  pc = new PiContext();


        }
        public Patient getUserByID(string UserID)
        {
            return UOW.getRepository<Patient>().GetById(UserID);
        }

        public void Update(Patient r)
        {
            throw new NotImplementedException();
        }

        public void updateUser(User u)
        {
            UOW.getRepository<User>().Update(u);
            UOW.Commit();
        }


    }

}
