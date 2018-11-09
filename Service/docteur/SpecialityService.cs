using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.docteur
{
   public class SpecialityService: Service<Speciality>, IServiceSpeciality
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);
        public SpecialityService() : base(uow)
        {

        }
    }
}
