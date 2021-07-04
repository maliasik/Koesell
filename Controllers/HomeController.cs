using Koesell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koesell.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(5).ToList());
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Search(string aranan)
        {
            var p = db.Products.Where(i => i.IsApproved == true);
            if(!string.IsNullOrEmpty(aranan))
            {
                p = p.Where(i => i.Name.Contains(aranan) || i.Description.Contains(aranan));
            }
            return View(p.ToList());
        }
        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(i => i.IsHome && i.IsApproved).ToList());
        }
        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i => i.CategoryId == id).ToList());
        }
    }
}