using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Entities.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines;
        public Cart()
        {
            _cartLines = new List<CartLine>();
        }
        public void AddToCart(Product product, int quantity)
        {
            CartLine cartLine = _cartLines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);
            if (cartLine == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }
        public void RemoveFromCart(Product product)
        {

            _cartLines.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }
        public decimal Total
        {
            get
            { return (decimal)_cartLines.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
        public List<CartLine> cartLines
        {
            get { return _cartLines; }
        }
    }
}
