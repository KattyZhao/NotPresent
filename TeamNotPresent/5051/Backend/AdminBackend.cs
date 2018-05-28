using _5051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Backend
{
    /// <summary>
    /// Avatar Backend handles the business logic and data for Avatars
    /// </summary>
    public class AdminBackend
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile AdminBackend instance;
        private static object syncRoot = new Object();

        private AdminBackend() { }

        public static AdminBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AdminBackend();
                            SetDataSource(SystemGlobals.Instance.DataSourceValue);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
        private static IAdminInterface DataSource;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            if (dataSourceEnum == DataSourceEnum.SQL)
            {
                // SQL not hooked up yet...
                throw new NotImplementedException();
            }

            // Default is to use the Mock
            DataSource = AdminDataSourceMock.Instance;
        }

        /// <summary>
        /// Makes a new Student
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Student Passed In</returns>
        public AdminProfileModel Create(AdminProfileModel data)
        {
            DataSource.Create(data);
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

            var myReturn = DataSource.Read(id);
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

            var myReturn = DataSource.Update(data);

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

            var myReturn = DataSource.Delete(Id);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Students</returns>
        public List<AdminProfileModel> StudentHome()
        {
            var myData = DataSource.StudentHome();
            return myData;
        }

        /// <summary>
        /// Helper that returns the First Student ID in the list, this will be used for creating new Students if no StudentID is specified
        /// </summary>
        /// <returns>Null, or Student ID of the first avatar in the list.</returns>
        public string GetFirstStudentId()
        {
            string myReturn = null;

            var myData = DataSource.StudentHome().ToList().FirstOrDefault();
            if (myData != null)
            {
                myReturn = myData.Id;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper function that returns the Student Image URI
        /// </summary>
        /// <param name="data">The avatarId to look up</param>
        /// <returns>null, or the Student image URI</returns>
        public string GetStudentUri(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string myReturn = null;

            var myData = DataSource.Read(data);
            if (myData != null)
            {
                myReturn = myData.Uri;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper that gets the list of Items, and converst them to a SelectList, so they can show in a Drop Down List box
        /// </summary>
        /// <param name="id">optional paramater, of the Item that is currently selected</param>
        /// <returns>List of SelectListItems as a SelectList</returns>
        public List<SelectListItem> GetStudentListItem(string id = null)
        {
            var myDataList = DataSource.StudentHome();

            //var myReturn = new SelectList(myDataList);

            var myReturn = myDataList.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id,
                Selected = (a.Id == id),
            }).ToList();

            return myReturn;
        }

        /// <summary>
        /// Helper function that resets the DataSource, and rereads it.
        /// </summary>
        public void Reset()
        {
            DataSource.Reset();
        }
    }
}