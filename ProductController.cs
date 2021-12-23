using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpAssignment2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CSharpAssignment2.Controllers
{
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;
        private MyDatabaseContext context;
        public ProductController(ILogger<ProductController> logger, MyDatabaseContext ctx)
        {
            context = ctx;
            _logger = logger;
        }
        public IActionResult Home()
        {
            try
            {
                var product = (from t in context.Products select t).Take(5);
                //var product = context.Products.ToList();
                return View(product);
            }
            catch (Exception e)
            {
                return View("Oops, Error getting data from Database!!");
            }
        }
        
        public async Task<IActionResult> Products( int id)
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                // productid = Int32.Parse(TempData["id"].ToString());
                var pid = id;
                HttpContext.Session.SetString("pid", id.ToString());
                var product = from prod in context.Products where prod.productId== pid select prod;
                return View(await product.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Products( Products product, string buy, string toCart)
        {
            string name = HttpContext.Session.GetString("uname");
            if (name != null && name != "admin")
            {
                if (buy != null)
                {
                    return RedirectToAction("Checkout", "User");
                }
                else if (toCart != null)
                {
                    var user = from usr in context.User where usr.username == name select usr;
                    foreach (var i in user)
                    {
                        int userid = Convert.ToInt32(i.userId);
                        string pid = HttpContext.Session.GetString("pid");
                        int id = Convert.ToInt32(pid);
                        var p = from prod in context.Products where prod.productId == id select prod;
                        foreach (var item in p)
                        {
                            Cart cart = new Cart
                            {
                                price = item.price,
                                quantity = 1,
                                productId = item.productId,
                                userId = userid,
                                status = "added to cart"
                            };
                            context.Cart.Add(cart);
                        }
                    }
                    context.SaveChanges();
                    return RedirectToAction("Cart", "User");
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
       
        }
        
    }
}
