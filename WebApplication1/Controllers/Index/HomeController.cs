using AccessDbTools;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string conStr = RSRC.Setting.CNSTR + 
                HttpContext.Server.MapPath("/Data_st/db.mdb");
            ViewBag.Title = AdminTools.GetInfoByTable("sTitle", "tblSetting", 
                conStr);

            var lstCats = AdminTools.GetComboList(
                "Select catName,catID From tblCats",
                "catName", 
                "catID", 
                conStr);

            ViewBag.List = ToSelectList(lstCats, "CityID", "CityName");

            return View();
        }

    }
}