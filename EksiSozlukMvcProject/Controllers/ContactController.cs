using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiSozlukMvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        CantactValidator cv = new CantactValidator();
        public ActionResult Index()
        {
            var contactValue = cm.GetList();
            return View(contactValue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}