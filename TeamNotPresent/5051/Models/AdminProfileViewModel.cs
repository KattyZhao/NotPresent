using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    /// View Model for the Student Views to have the list of Students
    /// </summary>
    public class AdminProfileViewModel
    {
        /// <summary>
        /// The List of Students
        /// </summary>
        public List<AdminProfileModel> StudentList = new List<AdminProfileModel>();
    }
}