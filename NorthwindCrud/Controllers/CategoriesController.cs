using NorthwindCrud.Models.Data;
using NorthwindCrud.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindCrud.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        NorthwindEntities db = new NorthwindEntities();
        CategoriesModel model = new CategoriesModel();
        public ActionResult Liste()
        {
            model.clist = db.Categories.ToList();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.categories = db.Categories.Find(id);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Guncel(int id)
        {
            model.categories = db.Categories.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Guncel(int id,CategoriesModel cm)
        {
            Categories seccategories = db.Categories.Find(id);
            seccategories.CategoryName = cm.categories.CategoryName;
            seccategories.Description = cm.categories.Description;
            db.SaveChanges();

            return RedirectToAction("Liste");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            model.categories = db.Categories.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Sil(int id,bool deger =true)
        {
            Categories silcat = db.Categories.Find(id);
            db.Categories.Remove(silcat);
            db.SaveChanges();

            return RedirectToAction("Liste");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            model.categories = new Categories();
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(CategoriesModel cm)
        {
            Categories c = new Categories();
            c.CategoryName = cm.categories.CategoryName;
            c.Description = cm.categories.Description;
            db.Categories.Add(c);
            db.SaveChanges();
            
            return RedirectToAction("Liste");
        }

    }
}