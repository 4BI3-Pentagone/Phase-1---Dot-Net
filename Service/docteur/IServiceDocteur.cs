using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.docteur
{
  public  interface IServiceDocteur: IService<Doctor>
    {
        IEnumerable<Doctor> GetDoctorsById(String id );
        Doctor GetDOctorByid(String id);
        IEnumerable<Doctor> GetFiveMostVisitedDoctorsBySpeciality();
        IEnumerable<Doctor> GetDoctorsByEmail(String email);
    }
}
