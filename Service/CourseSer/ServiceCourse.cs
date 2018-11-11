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

namespace Service.CourseSer
{
    public class ServiceCourse : Service<Course>, IServiceCourse

    {
        ServiceDoctor sd = new ServiceDoctor();
        ServicePatient sp = new ServicePatient();
        ServiceAppointment sa = new ServiceAppointment();
        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
       
        public ServiceCourse() : base(UOW)
        {
           

        }


        // public 


        public  IEnumerable<Patient> GetMyPatients(Doctor d)
        {
            //var facture = UOW.getRepository<Facture>().GetMany(F => F.Client == c);
            /* var req = from f in facture
                       select f.produit;
             return req;*/

            var ls = UOW.getRepository<Appointment>().GetMany(P => P.doctor == d);
            var req = from l in ls
                      select l.patient;
            return req;
        }
        public void CreateStep(Patient p, Step s)
        {
            Course c = new Course();
            c = p.course;
        }

    }
}
