using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    /// <summary>
    /// Backend Mock DataSource for Avatars, to manage them
    /// </summary>
    public class AdminDataSourceMock : IAdminInterface
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile AdminDataSourceMock instance;
        private static object syncRoot = new Object();

        private AdminDataSourceMock() { }

        public static AdminDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AdminDataSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The Avatar List
        /// </summary>
        private List<AdminProfileModel> StudentList = new List<AdminProfileModel>();

        /// <summary>
        /// Makes a new Avatar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public AdminProfileModel Create(AdminProfileModel data)
        {
            StudentList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public AdminProfileModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = StudentList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public AdminProfileModel Update(AdminProfileModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = StudentList.Find(n => n.Id == data.Id);
            myReturn.Uri = data.Uri;
            myReturn.Name = data.Name;
            myReturn.PowerId = data.PowerId;
            myReturn.PersonalContact = data.PersonalContact;
            myReturn.GuardianContact = data.GuardianContact;
            myReturn.Address = data.Address;


            return myReturn;
        }

        /// <summary>
        /// Remove the Data item if it is in the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for success, else false</returns>
        public bool Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            var myData = StudentList.Find(n => n.Id == Id);
            var myReturn = StudentList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Avatars</returns>
        public List<AdminProfileModel> StudentHome()
        {
            return StudentList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            StudentList.Clear();
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
          
            Create(new AdminProfileModel("african-american-maile-student-in-unifrom-with-backpack-clipart.jpg", "Jack", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-student-with-bagpack-happily-jump-in-the-air-back-to-school-clipart.jpg", "Jea", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-student-with-his-bag-pack-and-book-back-to-school-clipart.jpg", "Kevin", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-wearing-glasses-reading-book-back-to-school-clipart.jpg", "Issac", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("girl-student-back-to-school-clipart-2.jpg", "Diamond", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("smiling-cute-girl-with-her-bag-pack-back-to-school-clipart.jpg", "Sheila", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-going-to-school-walking-and-waving-back-to-school-clipart-6726.jpg", "Bryce", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-student-with-bagpack-happily-jump-in-the-air-back-to-school-clipart.jpg", "Joey", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("boy-student-with-his-bag-pack-and-book-back-to-school-clipart.jpg", "Harry", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));
            Create(new AdminProfileModel("girl-showing-back-to-school-happily-clipart-2.jpg", "Rachel", "2345682", "564738289", "5784983977", "344,56th Ave,Marshall Road,Seattle,WA-98065"));

        }
    }
}