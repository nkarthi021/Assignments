using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_Assignment_2.EmployeeService;

namespace WCF_Assignment_2.Models

{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public List<Employee> EmployeeList { get; set; }
    }
}