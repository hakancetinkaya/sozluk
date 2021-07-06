using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationsRules;

namespace EksiSozlukMvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
        WriterManager wm = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
          string  param = (string)Session["WriterEmail"];
            ViewBag.d = param;
             id = c.Writers.Where(x => x.WriterEmail == param).Select(y => y.WriterID).FirstOrDefault();
            var wirterValue = wm.GetById(id);
            return View(wirterValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            WriterValidator validationRules1 = new WriterValidator();
            ValidationResult result = validationRules1.Validate(w);
            if (result.IsValid)
            {
                wm.WriterUpdate(w);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string param)
        {//id=5
          
            param = (string)Session["WriterEmail"];
            var writerIdValue= c.Writers.Where(x => x.WriterEmail == param).Select(y => y.WriterID).FirstOrDefault();
           // ViewBag.d = writerIdValue;
            var values = hm.GetListByWriter(writerIdValue);
            return View(values);
        }

        public ActionResult NewHeading()
        {            
            List<SelectListItem> valueHeading = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();

            ViewBag.vlh = valueHeading;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading) { 
        

            string mail = (string)Session["WriterEmail"];
            var writerIdValue = c.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdValue;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCateory = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.vlc = valueCateory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeaidingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {            
            var headings = hm.GetList().ToPagedList(page,4);
            return View(headings);
        }
    }
}