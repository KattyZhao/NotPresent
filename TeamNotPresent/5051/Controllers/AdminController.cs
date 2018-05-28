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
        // A ViewModel used for the Avatar that contains the StudentList
        private AdminProfileViewModel AdminProfileViewModel = new AdminProfileViewModel();

        // The Backend Data source
        private AdminBackend AdminBackend = AdminBackend.Instance;

        // GET: Student
        /// <summary>
        /// Index, the page that shows all the Students
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentHome()
        {
            // Load the list of data into the StudentList
            AdminProfileViewModel.StudentList = AdminBackend.StudentHome();
            return View(AdminProfileViewModel);
        }

        /// <summary>
        /// Read information on a single Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Details/5
        public ActionResult Read(string id = null)
        {
            var myData = AdminBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This opens up the make a new Student screen
        /// </summary>
        /// <returns></returns>
        // GET: Student/Create

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult MainHome()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            var myData = new AdminProfileModel();
            return View(myData);
        }

        /// <summary>
        /// Make a new Student sent in by the create Studentscreen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Include=
                                        "Id,"+
                                        "Uri,"+
                                        "Name,"+
                                        "PowerId,"+
                                        "PersonalContact,"+
                                        "GuardianContact," +
                                        "Address,"+
                                        "")] AdminProfileModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (data == null)
                    {
                        return RedirectToAction("Error", new { route = "Home", action = "Error" });
                    }

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        return View(data);
                    }

                    AdminBackend.Create(data);

                    return RedirectToAction("StudentHome");
                }

                // Send back for edit
                return View(data);
            }
            catch
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }
        }

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult StudentCalendar()
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
        public ActionResult Update(string id = null)
        {
            var myData = AdminBackend.Read(id);
            return View(myData);
        }
        /// <summary>
        /// This updates the Student based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Student/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=  "Id," +
                                                   "Uri," +
                                                   "Name," + 
                                                   "PowerId," +
                                                   "PersonalContact," +
                                                   "GuardianContact," +
                                                   "Address," +
                                                    "")] AdminProfileModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (data == null)
                    {
                        return RedirectToAction("Error", new { route = "Home", action = "Error" });
                    }

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        return View(data);
                    }

                    AdminBackend.Update(data);

                    return RedirectToAction("Home");
                }

                // Send back for edit
                return View(data);
            }
            catch
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }
        }

        public ActionResult Delete(string id = null)
        {
            var myData = AdminBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This deletes the Student sent up as a post from the Student delete page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST:Student/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = 
                                           "Id," +
                                            "Uri," +
                                            "Name,"+
                                            "PowerId,"+
                                             "PersonalContact,"+
                                             "GuardianContact,"+
                                             "Address"+
                                        "")] AdminProfileModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (data == null)
                    {
                        return RedirectToAction("Error", new { route = "Home", action = "Error" });
                    }

                    if (string.IsNullOrEmpty(data.Id))
                    {
                        return View(data);
                    }

                    AdminBackend.Delete(data.Id);

                    return RedirectToAction("StudentHome");
                }

                // Send back for edit
                return View(data);
            }
            catch
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

        }

        public ActionResult Print()
        {
            return View();
        }


    }
}