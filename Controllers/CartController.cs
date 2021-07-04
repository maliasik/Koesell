using Koesell.Entity;
using Koesell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koesell.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext(); //Veritabanı bağlantısı.
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart, ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString(); //A harfiyle başlayıp 4 haneli sipariş numarası üretecek.
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order); //Siparişleri veritabanında ki orders a ekleyecek.
            db.SaveChanges();
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if(cart.CartLines.Count==0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde Ürün Bulunamadı");
            }
            if(ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("SiparisTamamlandi");
            }
            else
            {
                return View(model);
            }

        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if(product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart==null) //Eğer sepet boşsa yeni oluşturur yoksa oluşan sepete eklemeye devam eder.
            {
                cart = new Cart();
                Session["Cart"]= cart;
            }
            return cart;
        }
    }
}