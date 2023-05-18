using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            var lstCity = new List<Models.City>();

            lstCity.Add(new Models.City { CityID = 1, CityName = "Tehran" });
            lstCity.Add(new Models.City { CityID = 2, CityName = "Rasht" });

            ViewBag.City = new SelectList(lstCity, "CityID", "CityName");
            return View();
        }
    }
}