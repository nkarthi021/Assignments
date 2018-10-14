using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF_Assignment_2.EmployeeService;

namespace WCF_Assignment_2.Controllers
{
    public class TempreatureController : Controller
    {
        EmpServiceClient client = new EmpServiceClient("BasicHttpBinding_IEmpService");
        // GET: Tempreature
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult celtoFar(int value)
        {
            double output = client.CelsiustoFahrenheit(value);

            return Json( new { output = output  }, JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public ActionResult FartoCel(int value)
        {
            double output = client.FahrenheittoCelcius(value);

            return Json(new { output = output }, JsonRequestBehavior.AllowGet);
        }
    }
}