using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SystemLibraryData;
using SystemLibraryData.Entity;

namespace AppointmentProject.Controllers
{

    public class AppointmentController : Controller
    {
        Patient patient = new Patient();
        Appointment apt = new Appointment();
        AppointmentDataHandler appointment = new AppointmentDataHandler();
        DoctorDataHandler doctorDataHandler = new DoctorDataHandler();

        bool chkOutput;

        public IActionResult Index()
        {
            var output = GetAppointments();

            ViewBag.Doctor = GetDoctors();

            return View(output);
        }

        public JsonResult GetAppointmentList()
        {
            var sa = new JsonSerializerSettings();
            var output = GetAppointments();

            return Json(output, sa);
        }

        public JsonResult GetAppointmentListByDate([FromBody] Date data)
        {
            var sa = new JsonSerializerSettings();
            var output = GetAppointments().Where(x => x.ApDate > data.Date1 && x.ApDate < data.Date2);

            return Json(output, sa);
        }

        public JsonResult GetDocFee([FromBody] Fee data)
        {
            var sa = new JsonSerializerSettings();
            var output = appointment.GetDoctorFee(data.DId);

            return Json(output, sa);
        }


        public IActionResult MakeAppointment([FromBody] AppointmentModel appointmentModel)
        {
            apt.Doctor = new Doctor();

            apt.CNo = appointmentModel.CNo;
            apt.Doctor.DId = appointmentModel.DId;
            apt.ApDate = appointmentModel.ApDate;
            apt.ChFee = appointmentModel.ChFee;
            apt.SpUsername = appointmentModel.SpUsername;

            chkOutput = appointment.MakeNewAppointment(apt);

            return Json(chkOutput);
        }


        public IActionResult PayFee([FromBody] Appointment ap)
        {
            int status = 0;

            if (ap.ChStatus == 0) status = 1;
            else status = 0;

            apt.ApId = ap.ApId;
            apt.ChStatus = status;
            apt.ChFee = ap.ChFee;
            apt.DId = ap.DId;

            chkOutput = appointment.UpdateChargeStatus(apt);

            return Json(chkOutput);
        }

        public IActionResult CancelAppointment([FromBody] Appointment ap)
        {


            apt.ApId = ap.ApId;
            apt.ApStatus = ap.ApStatus;
            apt.DId = ap.DId;

            chkOutput = appointment.UpdateAptStatus(apt);

            return Json(chkOutput);
        }

        public List<Appointment> GetAppointments()
        {
            return appointment.GetAppointmentData();
        }

        public List<Doctor> GetDoctors()
        {
            return doctorDataHandler.GetDoctorData<Doctor>();
        }
    }

    
}