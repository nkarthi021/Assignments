using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF_Assignment_2.EmployeeService;
using WCF_Assignment_2.Models;

namespace WCF_Assignment_2.Controllers
{
    public class EmployeeController : Controller
    {
        EmpServiceClient client = new EmpServiceClient("BasicHttpBinding_IEmpService");
        // GET: Employee
        public ActionResult Index(int? Id)
        {
            
            EmployeeViewModel empViewModel = new EmployeeViewModel();

            if(Id !=null)
            {
                empViewModel.Employee = client.GetEmployeeById(Id);
            }
            
            empViewModel.EmployeeList = client.GetAllEmployee();
            
            return View(empViewModel);
        }

        [HttpPost]
        public ActionResult AddorUpdate(Employee employee)
        {
            //EmployeeViewModel empViewModel = new EmployeeViewModel();
            if (employee.Id != 0)
                client.UpdateEmployee(employee);
            else
                client.InsertEmployee(employee);

            return Json(new { status = "Success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            //EmployeeViewModel empViewModel = new EmployeeViewModel();
            client.DeleteEmployee(Id);

            return Json(new { status = "Success" }, JsonRequestBehavior.AllowGet);
        }
    }

}