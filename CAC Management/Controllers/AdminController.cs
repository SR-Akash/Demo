using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAC_Management.DataBase;
using CAC_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAC_Management.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext db;

        [TempData]
        public string message { get; set; }
        public AdminController(DataContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoutineIndex(st_routine routine)
        {

            return View(db.student_routine.ToList());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin model)
        {
            var i = db.Admin.Where(x => x.Name == model.Name && x.Password == model.Password).FirstOrDefault();
            if (i != null)
            {
                ViewBag.Login = "Succeecful";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Login = "User Name or Password Invalid!!!";
                return View();
            }
        }

        public IActionResult TeacherAttendance()
        {
            return View();
        }
    
        public IActionResult Routine()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Routine(st_routine routine)
        {

            if(!ModelState.IsValid)
            {
                return View();
                
            }
            db.student_routine.Add(routine);
            await db.SaveChangesAsync();
            message = "Routine Successfully Added";
            return RedirectToAction(nameof(RoutineIndex));
        }
        public async Task<IActionResult>delete(int? id)
        {
           var pid= await db.student_routine.FindAsync(id);
            if(pid==null)
            {
                return NotFound();
            }
            return View(pid);

        }

        [HttpPost]
        public async Task<IActionResult>delete(int id, st_routine routine)
        {
            var pid = await db.student_routine.FindAsync(id);
            db.student_routine.Remove(pid);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(RoutineIndex));
        }
    }
}