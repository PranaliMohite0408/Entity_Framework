using DataBaseFirstApproachEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataBaseFirstEFEntities db = new DataBaseFirstEFEntities();
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
                    TempData["InsertMessage"] = "<script>alert('Data Inserted !!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted !!!')</script>";
                }
            }           
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(row);
        }

        [HttpPost]

        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();

                if(a > 0 )
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
            var Data = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(Data);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a  = db.SaveChanges();

                if(a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Deleted')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Not Deleted')</script>";
                }

            }

            return View();
        }


        public ActionResult Details(int id)
        {
            var data = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(data);
        }


    }   

}