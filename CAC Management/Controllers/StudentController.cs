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
    public class StudentController : Controller
    {
        private readonly DataContext db;
        public StudentController(DataContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Student model)
        {
            var i = db.Student.Where(x => x.StudentName == model.StudentName && x.Password == model.Password).FirstOrDefault();
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

        public IActionResult StudentAdmission()
        {
            return View();
        }

        [HttpPost, ActionName("StudentAdmission")]
        public async Task<IActionResult> Admission(Student s)
        {
            if(s.PayAmount>s.TuitionFee)
            {
                s.PayAmount = s.TuitionFee;
            }

            s.DueAmount = s.TuitionFee - s.PayAmount;
            if (s.DueAmount >= 1)
            {
                s.PaymentStatus = 1;
            }

            else
            {
                s.PaymentStatus = 0;
            }
            s.DueAmount2 = s.PayAmount;
            if (ModelState.IsValid)
            {
                db.Student.Add(s);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(StudentList));

            }
            return View(s);
        }

        public IActionResult StudentList()
        {
            var test = db.Student;
            var i = new List<Student>();
            foreach (var s in test)
            {
                Student t = new Student();
                t.StudentId = s.StudentId;
                t.StudentName = s.StudentName;
                t.FatherName = s.FatherName;
                t.MotherName = s.MotherName;
                t.DOB = s.DOB;
                t.Gender = s.Gender;
                t.Address = s.Address;
                t.Contact = s.Contact;
                t.Email = s.Email;
                t.Password = s.Password;
                t.TuitionFee = s.TuitionFee;
                t.PayAmount = s.PayAmount;
                t.DueAmount = s.DueAmount;
                t.PaymentStatus = s.PaymentStatus;
                i.Add(t);
            }
            ViewBag.msg = "Pay Your Due First";
            return View(i);
        }
        public IActionResult S_View()
        {
            var test = db.Student;
            var i = new List<Student>();
            foreach (var s in test)
            {
                Student t = new Student();
                t.StudentId = s.StudentId;
                t.StudentName = s.StudentName;
                t.FatherName = s.FatherName;
                t.MotherName = s.MotherName;
                t.DOB = s.DOB;
                t.Gender = s.Gender;
                t.Address = s.Address;
                t.Contact = s.Contact;
                t.Email = s.Email;
                t.Password = s.Password;
                t.TuitionFee = s.TuitionFee;
                t.PayAmount = s.PayAmount;
                t.DueAmount = s.DueAmount;
                t.PaymentStatus = s.PaymentStatus;
                i.Add(t);
            }
            ViewBag.msg = "Pay Your Due First";
            return View(i);
        }
        public IActionResult Search(int Id)
        {
            var l = db.Student.Find(Id);
            return RedirectToAction(nameof(StudentList));
        }

        public IActionResult StudentSearch(int Id)
        {
            var l = db.Student.Find(Id);
            return RedirectToAction(nameof(StudentList));
        }

        public IActionResult StudentDetails(int Id)
        {
            var n = db.Student.Find(Id);
            return View(n);
        }
        [HttpGet]
        public IActionResult EditStudent(int? Id)
        {

            var lid = db.Student.Where(x=> x.StudentId == Id).FirstOrDefault();
            if(lid.DueAmount>0)
            {
                ViewBag.msg = "Pay Your Dues First";
                return RedirectToAction("S_View");
            }
            return View(lid);
        }

        [HttpPost, ActionName("EditStudent")]
        public async Task<IActionResult> Edit(int Id, Student s)
        {

            if (s.PayAmount > s.TuitionFee)
            {
                s.PayAmount = s.TuitionFee;
            }
            //if (d != null)
            //{
            //    s.DueAmount = (s.TuitionFee - s.PayAmount) + d.DueAmount;
            //}

            s.DueAmount = (s.TuitionFee - s.PayAmount);
            Console.WriteLine(s.DueAmount);
            if (s.DueAmount >= 1)
            {
                s.PaymentStatus = 1;
            }

            else
            {
                s.PaymentStatus = 0;
            }

            if (Id != s.StudentId)
            {
                return NotFound();
            }
            
            s.DueAmount2 = s.PayAmount;
            
            db.Student.Update(s);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(StudentList));

        }
        public IActionResult PayDue(int? Id)
        {
            var lid = db.Student.Find(Id);
            return View(lid);
        }

        [HttpPost, ActionName("PayDue")]
        public async Task<IActionResult> PayDue(int Id, Student s)
        {
            if((s.DueAmount2+s.PayAmount)>=1)
            {
                s.DueAmount = 0;
                s.PayAmount = s.TuitionFee;
                s.TuitionFee=s.PayAmount+s.DueAmount2;
            }

            s.DueAmount = s.TuitionFee - s.PayAmount;
            if (s.DueAmount >= 1)
            {
                s.PaymentStatus = 1;
            }

            else
            {
                s.PaymentStatus = 0;
            }

            if (Id != s.StudentId)
            {
                return NotFound();
            }
            db.Student.Update(s);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(StudentList));

        }

        public IActionResult DeleteStudent(int Id)
        {
            var l = db.Student.Find(Id);
            db.Student.Remove(l);
            db.SaveChanges();
            return RedirectToAction(nameof(StudentList));
        }

        public IActionResult Result()
        {
            return View();
        }

        public IActionResult st_Payment()
        {
            return View();
        }

        public IActionResult st_Routine()
        {
            return View(db.student_routine.ToList());
        }
    }
}