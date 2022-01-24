using Autofac;
using EcommerceSolution.web.Areas.Admin.Models;
using EcommerceSolution.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSolution.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ProductModel>();
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
        //[HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Add(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreateProduct();
               return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = new ProductUpdateModel();
            model.LoadData(id);
            return View(model);
        }

         [ValidateAntiForgeryToken, HttpPost]
         public IActionResult Edit(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateProduct();
                return RedirectToAction("Index");
            }

            return View();
        }
        [ValidateAntiForgeryToken, HttpPost]

        public IActionResult Delete(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.DeleteProduct();
            }
            return RedirectToAction("Index");
        }

    }
}
