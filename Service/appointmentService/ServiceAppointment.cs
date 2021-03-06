﻿using Data;
using Data.Infrastructure;
using Domain;
using Service.DoctorServices;
using Service.PatientService;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Service.appointmentService
{
    public class ServiceAppointment : Service<Appointment>, IServiceAppointment

    {



            static DatabaseFactory DBF = new DatabaseFactory();
            static IUnitOfWork UOW = new UnitOfWork(DBF);
            PiContext pc;
       //     IServicePatient Ips;
          //  IServicesDoctor Ids;
            public ServiceAppointment() : base(UOW)
            {
                pc = new PiContext();
               // ps = new ServicePatient();
               // ds = new ServicesDoctor();

            }
        public void CreateAppointment(Appointment A)
        {
            UOW.getRepository<Appointment>().Add(A);
            UOW.Commit();
        }
        public IEnumerable<Appointment> GetAllS()
            {
                return pc.Appointments.ToList();
            }
            public void removeAppointment(int idct)
            {
            Appointment App = this.GetById(idct);
                this.Delete(App);
            }

            public void updateAppointment(Appointment ct)
            {
                this.Add(ct);
                this.Commit();
            }


       /* public Dictionary<string, int> StatDoctor(int id)
        {
            {

                var ss = from Appointment a in GetAllS()
                         group a by a.Date into g
                         select new { g.Key, Count = g.Count() };
                Dictionary<string, int> depart = new Dictionary<string, int>();
                foreach (var t in ss)
                {
                    depart.Add(t.Key.ToString(), t.Count);
                    Console.WriteLine(t.Key + "" + t.Count);
                }
                return depart;
            }
        }*/

    }


    
}
