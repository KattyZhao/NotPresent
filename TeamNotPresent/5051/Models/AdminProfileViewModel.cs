using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    /// View Model for the Avatar Views to have the list of Avatars
    /// </summary>
    public class AdminProfileViewModel
    {
        /// <summary>
        /// The List of Avatars
        /// </summary>
        public List<AdminProfileModel> StudentList = new List<AdminProfileModel>();
    }
}