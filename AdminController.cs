using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using CSharpAssignment2.Models;
using CSharpAssignment2.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace CSharpAssignment2.Controllers
{
    public class AdminController : Controller
    {
        private MyDatabaseContext context { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(MyDatabaseContext ctx,IWebHostEnvironment hostEnv)
        {
            context = ctx;
            webHostEnvironment = hostEnv;
        }
        public async Task<IActionResult> ManagerHome()
        {
            string adminname = HttpContext.Session.GetString("uname");

            if (adminname == "admin")
            {
                var product = from prod in context.Products orderby prod.productId select prod;
                return View(await product.ToListAsync());
            }
            else {
                return RedirectToAction("Login", "Login");
            }
            
        }

       
        public async Task<IActionResult> UnProcessedOrders()
        {
            string adminname = HttpContext.Session.GetString("uname");

            if (adminname == "admin")
            {
                var product = from prod in context.Products orderby prod.productId select prod;//change to unprocessed items
                return View(await product.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        public async Task< IActionResult> ModifyCancelItems()
        {
            string adminname = HttpContext.Session.GetString("uname");

            if (adminname == "admin")
            {
                var product = from prod in context.Products orderby prod.productId select prod;
                return View(await product.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

       
        public IActionResult AddItem()
        {
            string adminname = HttpContext.Session.GetString("uname");

            if (adminname == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(Products product)
        {
            if (ModelState.IsValid)
            {
               // string rootfolder = "uploadedimages";
               // rootfolder += Guid.NewGuid().ToString()+"_"+ product.productImge.FileName;
               // string wwwRootPath = Path.Combine(webHostEnvironment.WebRootPath,rootfolder);
              //  await product.productImge.CopyToAsync(new FileStream(wwwRootPath, FileMode.Create));


                Products prod = new Products
                 {               
                    productName = product.productName,
                    productDescription = product.productDescription,
                    price = product.price,
                    quantity = product.quantity,
                //    imageName = "/"+product.productImge.FileName + DateTime.Now.ToString("yymmssfff"),
                    

                };
                context.Add(prod);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(ModifyCancelItems));
            }
            return View();
        }

        public async Task<IActionResult> EditItem()
        {
            string adminname = HttpContext.Session.GetString("uname");

            if (adminname == "admin")
            {
                string strId = Request.Query["id"].ToString();
                int id = Convert.ToInt32(strId);
                var product = from prod in context.Products where prod.productId==id select prod;
                return View(await product.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(Products product)
        {
            if (ModelState.IsValid)
            {
                var data = context.Products.Find(product.productId);
                Products prod = new Products
                {
                    productName = product.productName,
                    productDescription = product.productDescription,
                    price = product.price,
                    quantity = product.quantity,
                };
                context.SaveChanges();
                return RedirectToAction("ModifyCancelItems", "Admin");
            }
            else {
                return RedirectToAction("ModifyCancelItems", "Admin");
            }
        }
        public IActionResult DeleteItem()
        {
            string strId = Request.Query["id"].ToString();
            int productid = Int32.Parse(strId);
            var emp = context.Products.Find(productid);
            var x = (from y in context.Products where y.productId == productid
                     select y).FirstOrDefault();
            context.Products.Remove(x);
            context.SaveChanges();
            return RedirectToAction("ModifyCancelItems", "Admin");
        }
    }
}
