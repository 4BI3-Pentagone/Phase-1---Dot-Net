using Data;
using Data.Infrastructure;
using Domain;
using Service.PatientService;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CourseSer
{
    public class ServiceCourse : Service<Domain.Course>, IServiceCourse

    {
      

        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
       
        public ServiceCourse() : base(UOW)
        {
           

        }
       

      

    }
}
