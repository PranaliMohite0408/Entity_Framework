using Student_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Info_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        StudentEntities db = new StudentEntities();
        public ActionResult Index()
        {
            var data = db.Student_Details.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student_Details S)
        {
            if(ModelState.IsValid == true)
            {
                db.Student_Details.Add(S);
                int a = db.SaveChanges();
                if(a>0)
                {
                    TempData["Message"] = "<script>alert('Data is Inserted')</script>";
                }
                else
                {
                    TempData["Message"] = "<script>alert('Data is Not Inserted')</script>";
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var Data = db.Student_Details.Where(model => model.Id == id).FirstOrDefault();
            
            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(Student_Details S)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(S).State = EntityState.Modified;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully ')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Not Updated Successfully ')</script>";
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var student = db.Student_Details.Find(id);

            if (student == null)
            {
                // If the student with the given ID is not found, you may handle the error here
                return HttpNotFound();
            }

            // Remove the student from the database
            db.Student_Details.Remove(student);
            db.SaveChanges();

            // Set a message to display after redirecting to the index page
            TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var data = db.Student_Details.Where(model => model.Id == id).FirstOrDefault();
            
            return View(data);
        }
    }
}