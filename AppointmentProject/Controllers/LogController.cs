using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SystemLibraryData;

namespace AppointmentProject.Controllers
{
    public class LogController : Controller
    {
        LogDataHandler log = new LogDataHandler();
        public IActionResult Index()
        {
              
            return View(GetLog());
        }

        public IActionResult GetLogData()
        {
            

            var sa = new JsonSerializerSettings();

            var logList = GetLog();

            return Json(logList, sa);
        }

        public JsonResult GetLogListByDate([FromBody] Date data)
        {
            var sa = new JsonSerializerSettings();
            var output = GetLog().Where(x => x.Date > data.Date1 && x.Date < data.Date2);

            return Json(output, sa);
        }

        public List<Log> GetLog()
        {
            return log.GetLogDataHandler<Log>();
        }
    }
}