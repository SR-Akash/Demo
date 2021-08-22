using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CAC_Management.Models;
using CAC_Management.DataBase;

namespace CAC_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        public HomeController(DataContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //// Users Start
        //public IActionResult AddUsers()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddUsers(Users c)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Users t = new Users
        //        {
        //            UserId = c.UserId,
        //            UserName = c.UserName,
        //            Email = c.Email,
        //            Password = c.Password,
        //        };
        //        db.Users.Add(c);
        //        db.SaveChanges();
        //        ViewBag.Success = "User Account Created Successfully.";
        //        ModelState.Clear();
        //    }
        //    return View();
        //}

        //public IActionResult UserList()
        //{
        //    var i = db.Users.ToList();
        //    var m = new List<Users>();
        //    foreach (var item in i)
        //    {
        //        Users l = new Users();
        //        l.UserId = item.UserId;
        //        l.UserName = item.UserName;
        //        l.Email = item.Email;
        //        l.Password = item.Password;
        //        m.Add(l);
        //    }
        //    return View(m);
        //}
        //public IActionResult ViewUserList()
        //{
        //    var test = db.Users;
        //    var i = new List<Users>();
        //    foreach (var l in test)
        //    {
        //        Users t = new Users();
        //        t.UserId = l.UserId;
        //        t.UserName = l.UserName;
        //        t.Email = l.Email;
        //        t.Password = l.Password;
        //        i.Add(t);
        //    }
        //    return View(i);
        //}

        //public IActionResult UserDetails(int Id)
        //{
        //    var i = db.Users.Find(Id);
        //    return View(i);
        //}

        //public IActionResult Search(int Id)
        //{
        //    var l = db.Users.Find(Id);
        //    return View(l);
        //}

        //public IActionResult EditUserDetails(int Id)
        //{
        //    var l = db.Users.Find(Id);
        //    return View(l);
        //}

        //[HttpPost]
        //public IActionResult EditUserDetails(Users c)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Users t = new Users
        //        {
        //            UserId = c.UserId,
        //            UserName = c.UserName,
        //            Email = c.Email,
        //            Password = c.Password,
        //        };
        //        db.Users.Update(t);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("ViewUserList");
        //}

        //public IActionResult DeleteUserData(int Id)
        //{
        //    var l = db.Users.Find(Id);
        //    db.Users.Remove(l);
        //    db.SaveChanges();
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
