
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Framework.Service;
using Framework.Model;
using Autofac.Integration.Mvc;
using Autofac;
using Framework.BLL;
using Framework.Service.BLLService;

namespace Framework.Controllers
{
    public class StudentController : Controller
    {
        //initialize service object
        IStudentService _StudentService;
        
        StudentBLL _studentBll;

        public StudentController(IStudentService studentService)
        {
            _StudentService = studentService;
        }

 
        public ActionResult Index()
        {
            return View(_StudentService.GetAll());
        }


        public ActionResult Details(int id)
        {
            var student = _StudentService.GetById(id);
            return View(student);
        }


        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _StudentService.Create(student);
                return RedirectToAction("Index");
            }
            return View("Create", student);

        }


      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndCharge(Student student)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                PaymentWithCC payWithCC = new PaymentWithCC();
                _studentBll = new StudentBLL(_StudentService, payWithCC);

                return RedirectToAction("Index");
            }
            return View(student);

        }



       
        public ActionResult Edit(int id)
        {
            Student student = _StudentService.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

     
        [HttpPost]
        public ActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                _StudentService.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);

        }

 
        public ActionResult Delete(int id)
        {
            Student student = _StudentService.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            Student student = _StudentService.GetById(id);
            _StudentService.Delete(student);
            return RedirectToAction("Index");
        }



    }
}
