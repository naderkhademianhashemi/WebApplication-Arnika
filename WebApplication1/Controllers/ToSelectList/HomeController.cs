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
    
        public SelectList ToSelectList(List<Categories> lst, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var row in lst)
            {
                list.Add(new SelectListItem()
                {
                    Text = row.catName,
                    Value = row.catID.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

       
    }
}