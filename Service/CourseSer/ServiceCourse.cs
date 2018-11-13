using Data;
using Data.Infrastructure;
using Domain;
<<<<<<< HEAD
=======
using Service.appointmentService;
using Service.PatientService;
>>>>>>> 22b02e64d51a80a21f57cb838d3d3f0e4910b095
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
        public Course getCourse(string id){

            return  this.GetById(sp.GetById(id).course.CourseId);
        }
      // 
        public int CourseNotDone(string d)
        {

        Patient p = UOW.getRepository<Patient>().Get(P => P.Id == d);

        Course c = this.Get(C => C.CourseId == p.course.CourseId);

            var ls = UOW.getRepository<Step>().GetMany(S => S.course.CourseId == c.CourseId);
            var fn = from l in ls
                     where l.state == State.Done
                     select l;
            return fn.Count();

        }

        // public 
        public IEnumerable<Appointment> GetMyCourse(string d)
        {

            //var facture = UOW.getRepository<Facture>().GetMany(F => F.Client == c);
            /* var req = from f in facture
                       select f.produit;
             return req;*/

            var ls = UOW.getRepository<Appointment>().GetMany(P => P.patient.Id == d);
            
            var req = from l in ls
                      where l.state== 0
                      select l 
                      ;
           return req;
        }
       /* public Patient GetPatient(String d)
        {
            
        }*/
        public  IEnumerable<Patient> GetMyPatients(String d)
        {
            //var facture = UOW.getRepository<Facture>().GetMany(F => F.Client == c);
            /* var req = from f in facture
                       select f.produit;
             return req;*/

            var ls = UOW.getRepository<Appointment>().GetMany(P => P.doctor.Id == d);
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
