using Koesell.Entity;
using Koesell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koesell.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.BekleyenSiparis = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.TamamlananSiparis = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparis = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.KargolananSiparis = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.UrunSayisi = db.Products.Count();
            model.SiparisSayisi = db.Orders.Count();
            return View(model);
        }
        public ActionResult BildirimMenusu()
        {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
        }
    }
}