using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        CRUD_DBEntities db = new CRUD_DBEntities();
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

        public ActionResult Create(Student S)
        {
            if(ModelState.IsValid == true)
            {
                db.Students.Add(S);
                int a =  db.SaveChanges();

                if(a>0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data is Inserted !!')</script>";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data is Not Inserted !!')</script>";
                }
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var data = db.Students.Where(model => model.Id == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student S)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(S).State = EntityState.Modified;

                int a = db.SaveChanges();

                if(a>0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data is Updated ')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Data is Not Updated ')</script>";
                }
            }

            return View();
        }

        public ActionResult Delete(Student S)
        {
            if (ModelState.IsValid == true)
            {
               db.Entry(S).State = EntityState.Deleted;

                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data is Deleted ')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteMessage"] = " <script>alert('Data is Not Deleted ')</script>";
                }
            }



            return View();
        }

    }
}