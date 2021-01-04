using Northwind.Entities;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    
    public class AdminController : Controller
    {
        IProductService _productService;
        public AdminController(IProductService _productService)
        {
            this._productService = _productService;
        }
        // GET: Default
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
        [Authorize]
        public ActionResult CreateNew()
        {
            return View(new Product());
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid)
            {

                _productService.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Edit(int productId)
        {
            Product product = _productService.Get(productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}