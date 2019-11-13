using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppointmentProject.Models;
using SystemLibraryData;
using Newtonsoft.Json;
using SystemLibraryData.BLL;

namespace AppointmentProject.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IPatient patientsData;
        Patient patient = new Patient();
        ServiceProvider serviceProvider = new ServiceProvider();
        bool chkOutput;
        private readonly IPatientDataHandler dataHandler;

        public HomeController(IPatientDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public IActionResult Index()
        {

            //var output = dataHandler.GetPatientsData<Patient>();

            return View();
        }

        [HttpGet]
        public JsonResult GetPatientList()
        {
            var sa = new JsonSerializerSettings();

            var output = dataHandler.GetPatientsData<Patient>();

            return Json(output, sa);
        }

        [HttpPost]
        public IActionResult CreateInfo([FromBody] PatientModel patientModel)
        {
            patient.CardInfo = new Card();

            patient.PName = patientModel.PName;
            patient.PSex = patientModel.PSex;
            patient.PTel = patientModel.PTel;
            patient.PAddress = patientModel.PAddress;
            patient.PDocumentNo = patientModel.PDocumentNo;
            patient.CardInfo.CNo = patientModel.CardNo;

            chkOutput = dataHandler.AddNewPatientData(patient);
            //return RedirectToAction("index");
            return Json(chkOutput);
        }

        [HttpPost]
        public IActionResult EditPatientInfo([FromBody]PatientModel patientModel)
        {
            patient.CardInfo = new Card();
            patient.PId = patientModel.PId;
            patient.PName = patientModel.PName;
            patient.PSex = patientModel.PSex;
            patient.PTel = patientModel.PTel;
            patient.PAddress = patientModel.PAddress;
            patient.PDocumentNo = patientModel.PDocumentNo;
            patient.CardInfo.CNo = patientModel.CardNo;

            chkOutput = dataHandler.EditPatientData(patient);

            return Json(chkOutput);
        }

        [HttpPost]
        public IActionResult Delete([FromBody]PatientModel patientModel)
        {
            chkOutput = dataHandler.DeletePatientData(patientModel.PId);

            return Json(chkOutput);
        }

        [HttpPost]  
        public IActionResult Login([FromBody]User user)
        {
            serviceProvider.SpUsername = user.Username;
            serviceProvider.SpPassword = user.Password;

            chkOutput = dataHandler.LoginUserHandler(serviceProvider);

            return Json(chkOutput);
        }

        public IActionResult Logout(string name)
        {
            dataHandler.LogoutUserHandler(name);

            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
