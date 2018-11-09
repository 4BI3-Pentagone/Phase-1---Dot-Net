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
    public class ServicePatient : Service<Domain.Patient>, IServicePatient

    {



        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        PiContext pc;


        public ServicePatient() : base(UOW)
        {
            pc = new PiContext();


        }
        public Patient getUserByID(string UserID)
        {
            return UOW.getRepository<Patient>().GetById(UserID);
        }
        public void updateUser(User u)
        {
            UOW.getRepository<User>().Update(u);
            UOW.Commit();
        }


    }
}
