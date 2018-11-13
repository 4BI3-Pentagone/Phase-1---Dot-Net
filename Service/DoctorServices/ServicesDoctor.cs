using Data;
using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DoctorServices
{
   public class ServicesDoctor: Service<Doctor>, IServicesDoctor
    {
        static DatabaseFactory DBF = new DatabaseFactory();
            static IUnitOfWork UOW = new UnitOfWork(DBF);
        IDatabaseFactory dbfactory = null;
        PiContext ct;
        public ServicesDoctor():base(UOW)
        {
            ct = new PiContext();

        }
       
    }
}
