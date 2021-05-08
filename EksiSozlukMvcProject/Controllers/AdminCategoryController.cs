﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiSozlukMvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var categoryVal = cm.GetList();
            return View(categoryVal);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator rules = new CategoryValidator();
            ValidationResult result = rules.Validate(c);
            if (result.IsValid)
            {
                cm.CategoryAddBL(c);
                return RedirectToAction("Index");
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
    }
}