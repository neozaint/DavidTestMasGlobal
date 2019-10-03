using Domain.ServicesDomain;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace waTest.Controllers
{
    /// <summary>
    /// Controller of the Index Page.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        /// <summary>
        /// Api method that get employees.
        /// </summary>
        /// <param name="employePar"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetEmployees(EmployeDTO employeModel)
        {
            try
            {
                EmployeServices employeBL = new EmployeServices();
                List<EmployeDTO> employes = await employeBL.GetEmployees(employeModel);
                ViewBag.Employees = employes;

                return View("Index");
                
            }
            catch (Exception ex)
            {
                return View("Error",ex);
            }
        }
    }
}