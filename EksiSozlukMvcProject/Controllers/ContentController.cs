using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiSozlukMvcProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        //içeriğin bağlı olduğu başlık
        public ActionResult ContentByHeading(int id)
        {
            var contentValuses = cm.GetListByHeadingId(id);
            return View(contentValuses);
        }
    }
}