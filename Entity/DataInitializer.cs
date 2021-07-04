using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Koesell.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="Bilgisayar", Description="Bilgisayar & Aksesuarları"},
                new Category() {Name="Telefon", Description="Telefon & Aksesuarları"},
                new Category() {Name="Televizyon", Description="Televizyon & Ses Sistemleri"},
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product() {Name="Asus", Description="Bilgisayar & Aksesuarları",Price=4800,Stock=150,IsHome=false,IsApproved=true,IsFeatured=false,Slider=true,CategoryId=1,Image="1.jpg" },
                new Product() {Name="Samsung", Description="Telefon & Aksesuarları",Price=3300,Stock=120,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=2,Image="2.jpg" },
                new Product() {Name="Lg", Description="Televizyon & Ses Sistemleri",Price=2500,Stock=75,IsHome=true,IsApproved=true,IsFeatured=true,Slider=false,CategoryId=3,Image="3.jpg" },
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}