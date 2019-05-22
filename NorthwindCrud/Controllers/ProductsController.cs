using NorthwindCrud.Models.Data;
using NorthwindCrud.Models.DTOS;
using NorthwindCrud.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindCrud.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        NorthwindEntities db = new NorthwindEntities();
        ProductsModel model = new ProductsModel();
        public ActionResult Liste()
        {
            model.plist = db.Products.Select(x => new ProductsDTO
            {
                ProductId = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Categories.CategoryName,
                CompanyName = x.Suppliers.CompanyName,
                UnitPrice = (decimal)x.UnitPrice,
                QuanittyPer = x.QuantityPerUnit,
                Discontined = x.Discontinued

            }).ToList();
            return View(model);
        }

        public ActionResult Detay(int id)
        {
            model.Products = db.Products.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncel(int id)
        {
            DropDownDoldur(model);
            model.Products = db.Products.Find(id);
            return View(model);
        }

        private void DropDownDoldur(ProductsModel model)
        {
            model.SupplierDropdown = db.Suppliers.Select(x => new SelectListItem() { Text = x.CompanyName, Value = x.SupplierID.ToString() }).ToList();
            model.CategoriesDropdown = db.Categories.Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
        }

        [HttpPost]
        public ActionResult Guncel(ProductsModel pm)
        {
            // Products secproduct = pm.Products;
            //secproduct.ProductName = pm.Products.ProductName;
            //secproduct.UnitPrice = pm.Products.UnitPrice;
            //secproduct.QuantityPerUnit = pm.Products.QuantityPerUnit;
            //secproduct.Discontinued = pm.Products.Discontinued;
            if (ModelState.IsValid)
            {
                db.Entry(pm.Products).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            else
            {
                DropDownDoldur(model);
                return View(model);
            }

        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            model.Products = db.Products.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sil(int id, bool a = true)
        {
            //Products silprod = db.Products.Find(id);
            //db.Products.Remove(silprod);
            db.Entry(db.Products.Find(id)).State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
            return RedirectToAction("Liste");

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            DropDownDoldur(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(ProductsModel pm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pm.Products).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            else
            {
                DropDownDoldur(model);
                return View(model);
            }

        }

        public ActionResult Paging(int id,ProductsModel pm)
        {
            if (pm.GirilenSayfaNo==0)
            {
                pm.GirilenSayfaNo = 10;
            }
            //List<Products> plist= db.Products.OrderBy(x=>x.ProductID).Skip(20).Take(10).ToList();
            //model.ToplamSayfa =(int)Math.Ceiling(Convert.ToDecimal(db.Products.Count() / 10) + 0.5m);
            model.ToplamSayfa = (int)Math.Ceiling(Convert.ToDecimal(db.Products.Count() / pm.GirilenSayfaNo) + 0.5m);
            model.plist = db.Products.Select(x => new ProductsDTO
            {
                ProductId = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Categories.CategoryName,
                CompanyName = x.Suppliers.CompanyName,
                UnitPrice = (decimal)x.UnitPrice,
                QuanittyPer = x.QuantityPerUnit,
                Discontined = x.Discontinued

            }).OrderBy(x => x.ProductId).Skip((id-1)*pm.GirilenSayfaNo).Take(pm.GirilenSayfaNo).ToList();



            return View(model);

        }



    }
}