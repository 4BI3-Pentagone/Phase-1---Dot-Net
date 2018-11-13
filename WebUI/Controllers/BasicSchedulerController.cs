using Data;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
namespace WebUI.Controllers
{
    public class BasicSchedulerController : Controller
    {
        // GET: BasicScheduler
       
          /*  public ActionResult Index()
            {
               // var sched = new DHXScheduler(this);
               // sched.Skin = DHXScheduler.Skins.Terrace;
               // sched.LoadData = true;
                sched.EnableDataprocessor = true;
                sched.InitialDate = new DateTime(2018,11,10);
                return View(sched);
            }

            public ContentResult Data()
            {
                return (new SchedulerAjaxData(
                    new PiContext().Appointments
                    .Select(e => new { e.AppointmentId, e.Date, e.Disease, e.state,e.doctor,e.patient })
                    )
                    );
            }

            public ContentResult Save(int? id, FormCollection actionValues)
            {
                var action = new DataAction(actionValues);
                var changedEvent = DHXEventsHelper.Bind<Appointment>(actionValues);
                var entities = new PiContext();
                try
                {
                    switch (action.Type)
                    {
                        case DataActionTypes.Insert:
                            entities.Appointments.Add(changedEvent);
                            break;
                        case DataActionTypes.Delete:
                            changedEvent = entities.Appointments.FirstOrDefault(ev => ev.AppointmentId == action.SourceId);
                            entities.Appointments.Remove(changedEvent);
                            break;
                        default:// "update"
                            var target = entities.Appointments.Single(e => e.AppointmentId == changedEvent.AppointmentId);
                            DHXEventsHelper.Update(target, changedEvent, new List<string> { "id" });
                            break;
                    }
                    entities.SaveChanges();
                    action.TargetId = changedEvent.AppointmentId;
                }
                catch (Exception a)
                {
                    action.Type = DataActionTypes.Error;
                }

                return (new AjaxSaveResponse(action));
            }
        }
    }  
    */
    