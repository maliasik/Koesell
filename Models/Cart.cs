using Koesell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koesell.Models
{
    public class Cart
    {
        private List<Cartline> _cartLines = new List<Cartline>();
        public List<Cartline> CartLines
        {
            get { return _cartLines; } //Kullanıcının özel olarak sepetine ekleme düzenleme yapabilmesi.
        }
        public void AddProduct(Product product,int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if(line==null) //Ürün sepette yoksa
            {
                _cartLines.Add(new Cartline() { Product = product, Quantity = quantity }); //Sepette yoksa ekler.
            }
            else
            {
                line.Quantity += quantity; //Varsa adet artırır.
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }
        public double Total()
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity); //Adetle fiyatı çarpıp toplamı verir.
        }
        public void Clear()
        {
            _cartLines.Clear(); //Sepeti boşaltır.
        }
    }
    public class Cartline
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}