using _5051.Backend;
using _5051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        // GET: Student
        /// <summary>
        /// Index, the page that shows all the Students
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentHome()
        {
            // Load the list of data into the StudentList
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }
        
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult CalendarAddEvent()
        {
            return View();

        }
        public ActionResult CalendarEvent()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Print()
        {
            return View();
        }

    }       
}