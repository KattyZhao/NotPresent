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

        private StudentHomeViewModel myData = new StudentHomeViewModel();


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


        public ActionResult Home(string id = null)
        {
            // Get Student passed in, if no student then default a student.
            var myStudent = StudentBackend.Instance.Read(id);
            if (myStudent != null)
            {
                // Use this student
                myData.Student = myStudent;
            }
            else
            {
                // make a default student
                myStudent = StudentBackend.Instance.GetDefault();
            }

            // Put the student into the view model
            myData.Student = myStudent;

            // Change this in the future, add a new viewmodel, that combines the pin information with the student information for the home index

            // Katty  Add more example cities, about 10
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 30.058056, Longitude = 31.228889, Heading = "Egypt", Body = "Pyramids", color = "grey", Uri = "https://www.bing.com/th?id=OIP.Ll-ZME-_Anx_Y1J-qAY25AHaHa&pid=Api" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 51.5079, Longitude = -0.08772649, Heading = "London", Body = "Cool Bridge", color = "grey", Uri = "https://www.bing.com/th?id=OIP.Ll-ZME-_Anx_Y1J-qAY25AHaHa&pid=Api" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 47.61032, Longitude = -122.3206, Heading = "Seattle", Body = "SU", color = "grey", Uri = "https://www.bing.com/th?id=OIP.v2hpn5UE09t0gml2QWbAtAHaIb&pid=Api" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "Beijing", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "5", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "6", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "7", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "8", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "9", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.913818, Longitude = 116.363625, Heading = "10", Body = "the forbidden city", color = "grey", Uri = "https://image.flaticon.com/icons/png/128/198/198912.png" });




            // Mike:  Need to change the color of the map locaitons based on the cityCount, so for 1 to CityCount, the colore is Green, and from CityCount - Total count the color is grey

            // Katty  Write a loop that changes the color for the first number of places
            int count = 0;
            foreach (var item in myData.MapPinLocationsList)
            {
                if (count > myStudent.Cities)
                {
                    break;
                }

                item.color = "Green";
                count++;
            }

            return View(myData);
        }


        /// <summary>
        /// This Claim post will take 10 points from the account, and give a new Map pin.
        /// Then it redirects back to Home to show the updates
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult BuyPin([Bind(Include=
                                        "StudentId,"+
                                        "Points,"+
                                        "StudentOwnedPins,"+
                                        "")] StudentClaimViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (data == null)
                    {
                        return RedirectToAction("Error", new { route = "Home", action = "Error" });
                    }

                        //if (string.IsNullOrEmpty(data.StudentId))
                        //{
                        //    return RedirectToAction("Error", new { route = "Home", action = "Error" });
                        //}


                        var myStudent = StudentBackend.Instance.Read(data.StudentId);
                    if (myStudent == null)
                    {
                        return RedirectToAction("Error", new { route = "Home", action = "Error" });
                    }

                    // Buy the cities.
                    // See if they passed in the number of cities the person owns
                    // Use the number passed, int to be the number of cities to turn Green to show the user owns them
                    if (myStudent.Tokens >= 10)
                    {
                        // Pay 10 tokens and update the actual student
                        myStudent.Tokens = myStudent.Tokens - 10;
                        myStudent.Cities++;
                        StudentBackend.Instance.Update(myStudent);
                    }

                    // Call to return the home view.
                    return RedirectToAction("Home", "Student", new { id = data.StudentId });
                }

                return RedirectToAction("Error", new { route = "Home", action = "Error" });

            }
            catch
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }
        }

        public ActionResult Nav()
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

        public ActionResult Attendance()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


    }
}