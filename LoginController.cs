using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpAssignment2.Models;
using Microsoft.AspNetCore.Http;

namespace CSharpAssignment2.Controllers
{
    public class LoginController : Controller
    {

        private MyDatabaseContext context { get; set; }
        public LoginController(MyDatabaseContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user )
        {
                var u = from userdetails in context.User where userdetails.username==user.username select userdetails;
                if (u != null)
                {
                    HttpContext.Session.SetString("uname", user.username);
                    HttpContext.Session.SetString("pwd", user.password);
                    if (HttpContext.Session.GetString("uname") == "admin")
                    {
                        return RedirectToAction("ManagerHome", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Home", "Product");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Doesn't Exist");
                }
           
            return View();
        }

       [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Registration registration)
        {
            if (ModelState.IsValid)
            {
                User user = new User { username = registration.User.username, password = registration.User.password, confirmPassword = registration.User.confirmPassword };
                context.User.Add(user);
                context.SaveChanges();
                User u = context.User.Find(registration.User.userId);
                Registration reg = new Registration { address1 = registration.address1, address2 = registration.address2, postalCode = registration.postalCode,phoneNumber= registration.phoneNumber,User=user };              
                context.Registration.Add(reg);
                context.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        
    }
}
