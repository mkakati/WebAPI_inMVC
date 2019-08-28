using MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            //mvcEmployeeModel[] items = JsonConvert.DeserializeObject<mvcEmployeeModel[]>(empList);
            return View(empList);
        }
        // Post: Employee
        public ActionResult AddorEdit(int id=0)
        {
            if(id == 0 )
            
            return View(new mvcEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);

            }

        }
        [HttpPost]
        public ActionResult AddorEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfuly";
            return RedirectToAction("Index");
        }
    }
} 