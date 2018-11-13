using Data;
using Data.Infrastructure;
using Domain;
using Service.appointmentService;
using Service.PatientService;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StepsService
{
    public class ServiceStep : Service<Step>, IServiceStep

    {
       
        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
       
        public ServiceStep() : base(UOW)
        {
           

        }
      
    }
}
