using EFCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!!')</script>";

                    //TempData["InsertMessage"] = "<script>alert('Data Inserted !!!')</script>";

                    TempData["InsertMessage"] = "Data Inserted";
                    return RedirectToAction("Index");
                    
                    //ModelState.Clear();
                }
                else 
                {    
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!!')</script>";
                }
            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated !!!')</script>";

                    TempData["UpdateMessage"] = "<script>alert('Data Updated !!!')</script>";
                    return RedirectToAction("Index");

                    ModelState.Clear();
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated !!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if(id>0)
            {
                var StudentIdRow = db.Students.Where(model => model.ID == id).FirstOrDefault();

                if(StudentIdRow != null)
                {
                    db.Entry(StudentIdRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted!!!')</script>";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Nor Deleted!!!')</script>";
                    }
                }
            }
            return RedirectToAction("Index");

            //return View(StudentIdRow);
        }

        //[HttpPost]
        //public ActionResult Delete(Student s)
        //{
        //    db.Entry(s).State = EntityState.Deleted;
        //    int a = db.SaveChanges();
        //    if(a > 0)
        //    {
        //        TempData["DeleteMessage"] = "<script>alert('Data Deleted!!!')</script>";
        //    }
        //    else
        //    {
        //        TempData["DeleteMessage"] = "<script>alert('Data Nor Deleted!!!')</script>";
        //    }

        //    return RedirectToAction("Index");
        //}


        public ActionResult Details(int id)
        {
            var DetailsById = db.Students.Where(model => model.ID == id).FirstOrDefault(); 
            return View(DetailsById);
        }
    }
}