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

        //<summary>
        //get studentID
        //return to home view
        //</summary>
        public ActionResult Home(string id = null)
        {


            var myData = GetMapData(id);
            return View(myData);
        }

        //<summary>
        //get student Data passing in
        // if student is null, use default
        //</summary>
        public StudentHomeViewModel GetMapData(string id = null)
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

            // 10 example cities with description
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 30.058056, Longitude = 31.228889, Heading = "Egypt", Body = "Pyramids:The ancient Egyptians built pyramids as tombs for the pharaohs and their queens." +
                "The most famous Egyptian pyramids are those found at Giza, on the outskirts of Cairo. Several of the Giza pyramids are counted among the largest structures ever built. The Pyramid of Khufu at Giza is the largest Egyptian pyramid. It is the only one of the Seven Wonders of the Ancient World still in existence.", color = "grey", Uri = "/Content/img/card1.png", funfact = "They look like inverted ice-cream cones but are made up of sand"});
            
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 40.730610, Longitude = -73.935242, Heading = "New York, US", Body = "Brooklyn Bridge:The Brooklyn Bridge is a hybrid cable-stayed/suspension bridge in New York City and is one of the oldest roadway bridges in the United States. Started in 1869 and completed fourteen years later in 1883, it connects the boroughs of Manhattan and Brooklyn, spanning the East River. ", color = "grey", Uri = "/Content/img/cardny.png", funfact ="one of the oldest roadway bridges in United State" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 21.7679, Longitude = 78.8718, Heading = "Agra, India", Body = "Taj Mahal: Taj Mahalis is an ivory-white marble mausoleum on the south bank of the Yamuna river in the Indian city of Agra. It was commissioned in 1632 by the Mughal emperor, Shah Jahan, to house the tomb of his favourite wife, Mumtaz Mahal.", color = "grey", Uri = "/Content/img/card4.png", funfact = "World's most iconic tribute to love and it is made of marble" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 39.882211, Longitude = 116.406584, Heading = "Bejing, China", Body = "Temple of Heaven: Temple of Heaven is an imperial complex of religious buildings situated in the southeastern part of central Beijing. The complex was visited by the Emperors of the Ming and Qing dynasties for annual ceremonies of prayer to Heaven for good harvest.", color = "grey", Uri = "/Content/img/card6.png", funfact = "It is a  temple  mostly comprising prayers for good harvests." });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 35.652832, Longitude = 139.839478, Heading = "Honshu, Japan", Body = "Mt.Fuji: Mount Fuji's exceptionally symmetrical cone, which is snow-capped for about 5 months a year, is a well-known symbol of Japan and it is frequently depicted in art and photographs, as well as visited by sightseers and climbers.", color = "grey", Uri = "/Content/img/card3.png" , funfact = "It is the highest moutain and active vocano in Japan"});
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = -33.865143, Longitude = 151.209900, Heading = "Sydney, Australia", Body = "The Sydney Opera House is a multi-venue performing arts centre in Sydney, New South Wales, Australia. It is one of the 20th century's most famous and distinctive buildings. The building comprises multiple performance venues which together host well over 1,500 performances annually, attended by more than 1.2 million people.", color = "grey", Uri = "/Content/img/cardsy.png", funfact = "It is a muti-venue performing arts centre in Sydney" });
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = -8.409518, Longitude = 115.188916, Heading = "Bali, Indonesia", Body = "Pura Ulun Danu Bratan, is a major Shaivite water temple on Bali, Indonesia. Built in 1633, this temple is used for offerings ceremony to the Balinese water, lake and river goddess Dewi Danu, due to the importance of Lake Bratan as a main source of irrigation in central Bali.", color = "grey", Uri = "/Content/img/card7.png" , funfact = "A temple that in the middle of water"});
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 51.5079, Longitude = -0.08772649, Heading = "London, UK", Body = "Big Ben: Big Ben is the nickname for the Great Bell of the clock at the north end of the Palace of Westminster in London and is usually extended to refer to both the clock and the clock tower. When completed in 1859, its clock was the largest and most accurate four-faced striking and chiming clock in the world.", color = "grey", Uri = "/Content/img/cardbb.png" , funfact = "The house of Parliament's iconic clock tower"});
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 47.61032, Longitude = -122.3206, Heading = "Seattle, US", Body = "Space Needle: The Space Needle is an observation tower in Seattle, Washington, a landmark of the Pacific Northwest, and an icon of Seattle. It was built in the Seattle Center for the 1962 World's Fair, which drew over 2.3 million visitors, when nearly 20,000 people a day used its elevators.", color = "grey", Uri = "/Content/img/cardsn.png", funfact = "A needle doesnt look like needle"});
            myData.MapPinLocationsList.Add(new MapPinLocationModel { Latitude = 48.856614, Longitude = 2.352222, Heading = "Paris, France", Body = "Eiffel Tower: The Eiffel Tower is a wrought iron lattice tower on the Champ de Mars in Paris, France. It is named after the engineer Gustave Eiffel, whose company designed and built the tower. Constructed from 1887–89 as the entrance to the 1889 World's Fair, it was initially criticized by some of France's leading artists and intellectuals for its design, but it has become a global cultural icon of France and one of the most recognisable structures in the world.", color = "grey", Uri = "/Content/img/cardet.png",funfact = "It is famous because it was never supposed to stay there" });




            

            ///possible change pin color in the future
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

            return myData;
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

        /// <summary>
        /// This Claim post will take 10 points from the account, and give a new Map pin.
        /// Then it redirects back to Home to show the updates
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult ResetPin([Bind(Include=
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


                    myStudent.Tokens = 100;
                   
                    myStudent.Cities = 0;
                    StudentBackend.Instance.Update(myStudent);
                    

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

        public ActionResult PostCards(string id=null)
        {
            var myData = GetMapData(id);
            return View(myData);
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
        public ActionResult NavCopy()
        {
            return View();
        }
    }
}