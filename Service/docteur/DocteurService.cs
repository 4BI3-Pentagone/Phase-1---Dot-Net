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
   public class DocteurService: Service<Doctor>, IServiceDocteur
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
     
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public DocteurService() : base(uow)
        {

        }

        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality s)
        {
            //return GetMany(p => p.Category == c).OrderBy(p => p.Price) ; 
            //ou bien
            var req = from p in GetMany()
                      where p.Speciality == s
                      select p;
            return req;
        }
    }
}
