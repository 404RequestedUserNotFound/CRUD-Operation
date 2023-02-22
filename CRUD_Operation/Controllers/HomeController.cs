using CRUD_Operation.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD_Operation.Controllers
{
    public class HomeController : Controller
    {

        CRUD_OperationEntities entity = new CRUD_OperationEntities();

        public ActionResult Index()
        {
            var listofData = entity.Products.ToList();
            return View(listofData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product Model)
        {
            entity.Products.Add(Model);
            entity.SaveChanges();
            ViewBag.Massege = "Product Added to the inventory successfully";
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var data = entity.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditProduct(Product Model)
        {

            var data = entity.Products.Where(x => x.ProductId == Model.ProductId).FirstOrDefault();
            if (data != null)
            {
                data.ProductName = Model.ProductName;
                data.ProductPrice = Model.ProductPrice;
                data.ProductDetails = Model.ProductDetails;
                entity.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetailsProduct(int id)
        {
            var data = entity.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult DeleteProduct(int id)
        {
            var data = entity.Products.Where(x => x.ProductId == id).FirstOrDefault();
            entity.Products.Remove(data);
            entity.SaveChanges();
            ViewBag.Message = "Product Deleted Succesfully";
            return RedirectToAction("Index");
        }

    }
}