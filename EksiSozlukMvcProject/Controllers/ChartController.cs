using EksiSozlukMvcProject.Models;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiSozlukMvcProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass() {
            CategoryName="Yazılım",
            CategoryCount=9
            });
            ct.Add(new CategoryClass()
            {
                CategoryName="SSeyahat",
                  CategoryCount=9,
            });
            ct.Add(new CategoryClass()
            {
                 CategoryName="Teknoloji",
                  CategoryCount=7,
            });
            ct.Add(new CategoryClass()
            {
                 CategoryName="Spor",
                  CategoryCount=2,
            });
            return ct;
        }
      
    }
}