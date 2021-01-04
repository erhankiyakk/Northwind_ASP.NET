using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Entities.Models;
using Northwind.Interface;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;
        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: Cart
        public RedirectToRouteResult AddToCart(Cart cart,int productId)
        {
            Product product = productService.Get(productId);
            cart.AddToCart(product, 1);

            return RedirectToAction("Index",cart);
        }
        public ViewResult Index(Cart cart)
        {
            return View(cart);
        }
        public RedirectToRouteResult RemoveToCart(Cart cart,int productId)
        {
            Product product = productService.Get(productId);
            cart.RemoveFromCart(product);

            return RedirectToAction("Index",cart);
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                //Veri tabanına kayıt et

                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
            
        }
        public PartialViewResult CartSummary(Cart cart)
        {
            
            return PartialView(cart);
        }
    }
}