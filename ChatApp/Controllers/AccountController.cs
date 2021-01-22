using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatApp.ViewModels;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        // GET: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewM obj)
        {
            bool UserExists = db.Users.Any(x => x.Username == obj.Username);
            if(UserExists)
            {
                ViewBag.UsernameMessage = "This username already in use, try another";
                return View();
            }
            bool EmailExists = db.Users.Any(y => y.Email == obj.Email);
            if (EmailExists)
            {
                ViewBag.EmailMessage = "This Email already in use, try another";
                return View();
            }
            User u = new User();
            u.Username = obj.Username;
            u.Password = obj.Password;
            u.Email = obj.Email;
            u.ImageUrl = "";
            u.CreatedOn = DateTime.Now;

            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index" , "ChatRoom");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewM obj)
        {
            bool Exists = db.Users.Any(u => u.Username == obj.Username&&
            u.Password == obj.Password);
            if (Exists)
            {
                Session["UseID"] = db.Users.Single(x => x.Username == obj.Username).Id;
                Session["ImageUrl"] = db.Users.Single(x => x.Username == obj.Username).ImageUrl;
                return RedirectToAction("Index", "ChatRoom");
            }
            ViewBag.Message = "Invalid Credentials!";
                return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["UseID"] = 0;
            return RedirectToAction("Index","Home");
        }
    }
}