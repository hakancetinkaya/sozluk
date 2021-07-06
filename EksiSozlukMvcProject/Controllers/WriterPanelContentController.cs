using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiSozlukMvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string param, string param1)
        {
            param = (string)Session["WriterEmail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterEmail == param).Select(y=>y.WriterID).FirstOrDefault();
          //  ViewBag.d = param;
            var contentValuses = cm.GetListByWriter(writerIdInfo);
            return View(contentValuses);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
           string param = (string)Session["WriterEmail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterEmail == param).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}