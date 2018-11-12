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

        public IEnumerable<Doctor> GetDoctorsById(String id)
        {
            //return GetMany(p => p.Category == c).OrderBy(p => p.Price) ; 
            //ou bien
            var req = from p in GetMany()
                      where p.Id == id
                      select p;
            return req;
        }

        public Doctor GetDOctorByid(String id)
        {
            return uow.getRepository<Doctor>().GetById(id);
        }

        public IEnumerable<Doctor> GetFiveMostVisitedDoctorsBySpeciality()
        {
            var req = from p in GetMany()
                      orderby p.Speciality descending
                      select p;
            return req.Take(5);
        }

        public IEnumerable<Doctor> GetDoctorsByEmail(string email)
        {
            var req = from p in GetMany()
                      where p.Email == email
                      select p;
            return req;
        }
    }
}
