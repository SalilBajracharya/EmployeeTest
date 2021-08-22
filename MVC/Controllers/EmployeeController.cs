using MVC.Models;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        //EmployeeApi/GetALL
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _EmployeeList(string search)
        {
            string lowersearch = search.ToLower();
            IEnumerable<EmployeeMVC> empObj;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("EmployeesApi").Result;
            empObj = response.Content.ReadAsAsync<IEnumerable<EmployeeMVC>>().Result
                        .Where(x => x.Name.ToLower().Contains(lowersearch) || x.PhoneNo.Contains(lowersearch) || x.Skills.Contains(lowersearch)
                        || x.Address.ToLower().Contains(lowersearch));
            return PartialView("_EmployeeList", empObj);
        }

        //EmployeeApi/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeMVC obj)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var filename = "emp_" + Guid.NewGuid().ToString().Substring(0, 8) + ".jpg";
                file.SaveAs(Path.Combine(Server.MapPath("~/Uploads/"), filename));
                obj.Photo = filename;
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("EmployeesApi", obj).Result;
            return RedirectToAction("Index");
        }

        //EmployeeApi/DeleteEmployee
        public ActionResult DeleteEmployee(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("EmployeesApi/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

        //EmployeeApi/EditEmployee
        public ActionResult EditEmployee(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("EmployeesApi/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<EmployeeMVC>().Result);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeMVC obj)
        {
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var filename = "emp_" + Guid.NewGuid().ToString().Substring(0, 8) + ".jpg";
                file.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), filename));
                obj.Photo = filename;
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("EmployeesApi/" + obj.Id, obj).Result;
            return RedirectToAction("Index");
        }
    }
}