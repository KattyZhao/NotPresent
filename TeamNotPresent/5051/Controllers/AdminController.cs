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
        /// Index,Page which has the Logout Page 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        //Page that consits of all the Students
        public ActionResult StudentHome()
        {
            // Load the list of data into the StudentList
            AdminProfileViewModel.StudentList = AdminBackend.StudentHome();
            //The list view comes here
            return View(AdminProfileViewModel);
        }

        /// <summary>
        /// Read information on a single Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Details
        //When the student is selected, id is sent and the Page for that id is displayed
        public ActionResult Read(string id = null)
        {
            var myData = AdminBackend.Read(id);
            return View(myData);
        }

        
       
        //This Page displays the Student,Report, Calendar, Logout icons.
        public ActionResult MainHome()
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
        //All the variables required to create a student is displayed
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

        //this page displays the Attendance Report for the Student
        public ActionResult Report()
        {
            return View();
        }

        //The Admin can check the Student Calendar here, update it with any events and also view the holidays to schedule.
        public ActionResult StudentCalendar()
        {
            return View();
        }


        // GET: Student/Update
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
        // POST: Student/Update/
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

        // GET: Student/Delete
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

        //This page is just to display when Admin wants to sync the Calendar on his page to the  Calendaron Student's page so that Students can view events on their calendar.
        public ActionResult Sync()
        {
            return View();
        }


    }
}