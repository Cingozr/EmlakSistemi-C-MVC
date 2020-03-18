using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    public class AjandaController : Controller
    {
        // GET: FirmaPanel/Ajanda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Randevu()
        {
            return View();
        }

        EmlakSistemi.Models.EmlakContext appointmentContext = new EmlakSistemi.Models.EmlakContext();
        object resourceContext = null;

        public ActionResult SchedulerPartial()
        {
            var appointments = appointmentContext.Randevu;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerPartial");
        }
        public ActionResult SchedulerPartialEditAppointment()
        {
            var appointments = appointmentContext.Randevu;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            try
            {
                AjandaControllerSchedulerSettings.UpdateEditableDataObject(appointmentContext, resourceContext);
            }
            catch (Exception e)
            {
                ViewData["SchedulerErrorText"] = e.Message;
            }

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerPartial");
        }
    }
    public class AjandaControllerSchedulerSettings
    {
        static DevExpress.Web.Mvc.MVCxAppointmentStorage appointmentStorage;
        public static DevExpress.Web.Mvc.MVCxAppointmentStorage AppointmentStorage
        {
            get
            {
                if (appointmentStorage == null)
                {
                    appointmentStorage = new DevExpress.Web.Mvc.MVCxAppointmentStorage();
                    appointmentStorage.Mappings.AppointmentId = "Randevu_ID";
                    appointmentStorage.Mappings.Start = "Randevu_TARIHBAS";
                    appointmentStorage.Mappings.End = "Randevu_TARIHBIT";
                    appointmentStorage.Mappings.Subject = "Randevu_BASLIK";
                    appointmentStorage.Mappings.Description = "Randevu_ACIKLAMA";
                    appointmentStorage.Mappings.Location = "";
                    appointmentStorage.Mappings.AllDay = "";
                    appointmentStorage.Mappings.Type = "Randevu_ID";
                    appointmentStorage.Mappings.RecurrenceInfo = "";
                    appointmentStorage.Mappings.ReminderInfo = "";
                    appointmentStorage.Mappings.Label = "";
                    appointmentStorage.Mappings.Status = "";
                    appointmentStorage.Mappings.ResourceId = "";
                }
                return appointmentStorage;
            }
        }

        static DevExpress.Web.Mvc.MVCxResourceStorage resourceStorage;
        public static DevExpress.Web.Mvc.MVCxResourceStorage ResourceStorage
        {
            get
            {
                if (resourceStorage == null)
                {
                    resourceStorage = new DevExpress.Web.Mvc.MVCxResourceStorage();
                    resourceStorage.Mappings.ResourceId = "";
                    resourceStorage.Mappings.Caption = "";
                }
                return resourceStorage;
            }
        }

        public static void UpdateEditableDataObject(EmlakSistemi.Models.EmlakContext appointmentContext, object resourceContext)
        {
            InsertAppointments(appointmentContext, resourceContext);
            UpdateAppointments(appointmentContext, resourceContext);
            DeleteAppointments(appointmentContext, resourceContext);
        }

        static void InsertAppointments(EmlakSistemi.Models.EmlakContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Randevu.ToList();
            System.Collections.IEnumerable resources = null;

            var newAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToInsert<EmlakSistemi.Models.Randevu>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in newAppointments)
            {
                appointmentContext.Randevu.Add(appointment);
            }
            appointmentContext.SaveChanges();
        }
        static void UpdateAppointments(EmlakSistemi.Models.EmlakContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Randevu.ToList();
            System.Collections.IEnumerable resources = null;

            var updAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToUpdate<EmlakSistemi.Models.Randevu>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in updAppointments)
            {
                var origAppointment = appointments.FirstOrDefault(a => a.Randevu_ID == appointment.Randevu_ID);
                appointmentContext.Entry(origAppointment).CurrentValues.SetValues(appointment);
            }
            appointmentContext.SaveChanges();
        }

        static void DeleteAppointments(EmlakSistemi.Models.EmlakContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Randevu.ToList();
            System.Collections.IEnumerable resources = null;

            var delAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToRemove<EmlakSistemi.Models.Randevu>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in delAppointments)
            {
                var delAppointment = appointments.FirstOrDefault(a => a.Randevu_ID == appointment.Randevu_ID);
                if (delAppointment != null)
                    appointmentContext.Randevu.Remove(delAppointment);
            }
            appointmentContext.SaveChanges();
        }
    }

}