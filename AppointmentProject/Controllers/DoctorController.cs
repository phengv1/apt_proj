using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SystemLibraryData;

namespace AppointmentProject.Controllers
{
    public class DoctorController : Controller
    {
        DoctorDataHandler doctorDataHandler = new DoctorDataHandler();
        Doctor doc = new Doctor();
        bool chkOutput = false;

        public IActionResult Index()
        {
            return View(GetDoctors());
        }

        public JsonResult GetDoctorsList()
        {
            var sa = new JsonSerializerSettings();
            var output = GetDoctors();

            return Json(output, sa);
        }

        [HttpPost]
        public IActionResult EditDocStatus([FromBody]Doctor docModel)
        {
            doc.DId = docModel.DId;
            doc.DApQueue = docModel.DApQueue;
            doc.DStatus = docModel.DStatus;

            chkOutput = doctorDataHandler.UpdateDoctorDataHandler(doc);

            return Json(chkOutput);
        }

        public List<Doctor> GetDoctors()
        {
            return doctorDataHandler.GetDoctorData<Doctor>();
        }
    }
}