using CSharpAssignment2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpAssignment2.Controllers
{
    public class UserController : Controller
    {

        private MyDatabaseContext context { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(MyDatabaseContext ctx, IWebHostEnvironment hostEnv)
        {
            context = ctx;
            webHostEnvironment = hostEnv;
        }
        public IActionResult UserHome()
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                if (name != "" && name != null)
                {
                    return View();
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

        public async Task<IActionResult> Cart(Cart cart)
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                if (name != "" && name != null)
                {
                    var user = from usr in context.User where usr.username == name select usr;
                    foreach (var item in user)
                    {
                        var id = item.userId;
                        var product = from c in context.Cart where c.userId == id select c;
                        return View(await product.ToListAsync());
                    }
                    return View();
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

        public IActionResult Checkout()
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                if (name != "" && name != null)
                {
                    return View();
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

        public IActionResult Orders()
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                if (name != "" && name != null)
                {
                    return View();
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

        public IActionResult Success()
        {
            string name = HttpContext.Session.GetString("uname");

            if (name != "admin")
            {
                if (name != "" && name != null)
                {
                    return View();
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
