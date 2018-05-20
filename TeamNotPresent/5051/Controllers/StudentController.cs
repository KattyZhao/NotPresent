using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;


namespace _5051.Controllers
{
    public class StudentController : Controller
    {
        // A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        // GET: Student
        /// <summary>
        /// Index, the page that shows all the Students
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            // Load the list of data into the StudentList
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            //return View(StudentViewModel);
            return View();
        }


       public ActionResult Home()
        {
            return View(); 
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult PostCards()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        



    }
}
