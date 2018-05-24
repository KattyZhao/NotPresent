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
         // GET: Avatar/Details/5
        public ActionResult Profile(string id = null)
          {
                var myData = StudentBackend.Read(id);
                return View(myData);
          }

         
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View();
        }
        public ActionResult Create()
        {
            var myData = new StudentModel();
            return View(myData);
        }
        /// <summary>
        /// Make a new avatar sent in by the create avatar screen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Avatar/Create
        [HttpPost]
        public ActionResult Create([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "PowerId,"+
                                        "PersonalContact,"+
                                        "GuardianContact,"+
                                        "Address,"+
                                        "")] StudentModel data)
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

                    StudentBackend.Create(data);

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
        public ActionResult Edit(string id = null)
        {
            var myData = StudentBackend.Read(id);
            return View(myData);
        }
        /// <summary>
        /// This updates the avatar based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Avatar/Update/5
        [HttpPost]
        public ActionResult Edit([Bind(Include=
                                       "Id,"+
                                        "Name,"+
                                        "PowerId,"+
                                        "PersonalContact,"+
                                        "GuardianContact,"+
                                        "Address,"+
                                        "")] StudentModel data)
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

                    StudentBackend.Update(data);

                    return RedirectToAction("Index");
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
            var myData = StudentBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This deletes the avatar sent up as a post from the avatar delete page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Avatar/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "PowerId,"+
                                        "PersonalContact,"+
                                        "GuardianContact,"+
                                        "Address,"+
                                        "")] StudentModel data)
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

                    StudentBackend.Delete(data.Id);

                    return RedirectToAction("Index");
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