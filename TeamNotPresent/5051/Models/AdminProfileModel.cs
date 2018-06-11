using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _5051.Models
{
    /// <summary>
    /// Students for the system
    /// </summary>
    public class AdminProfileModel
    {
        //Student ID  which will generated automatically
        [Display(Name = "Student ID", Description = "Student's School Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        //Uri contains the Student's Picture
        [Display(Name = "Uri", Description = "Picture to Show")]
        [Required(ErrorMessage = "Picture is required")]
        public string Uri { get; set; }

        //Name will the Student'NAme
        [Display(Name = "Name", Description = "Student Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //Power ID will be the school's Id from a previoursly used system so that they can find the Student's previous ID from there 
        [Display(Name = "Power ID", Description = "Scholl's Previous System ID")]
        [Required(ErrorMessage = "PowerId is required")]
        public string PowerId { get; set; }

        //Student Contact will consist of Student's Phone Number
        [Display(Name = "Student Contact", Description = "Personal Phone Number")]
        [Required(ErrorMessage = "Student Contact is required")]
        public string PersonalContact { get; set; }

        //Guardian Contact will have Student's Guradian's Phone number
        [Display(Name = "Guardian Contact", Description = "Parent's Phone Number")]
        [Required(ErrorMessage = "Guardian Contact is required")]
        public string GuardianContact { get; set; }

        //Address will have the Student's House Address
        [Display(Name = "Address", Description = "Current Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        /// <summary>
        /// Create the default values
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// New Student
        /// </summary>
        public AdminProfileModel()
        {
            Initialize();
        }

        /// <summary>
        /// Make an Student from values passed in
        /// </summary>
        /// <param name="uri">The Picture path</param>
        /// <param name="name">Student Name</param>
        /// <param name="powerid">Student previous sytem id</param>
        ///  <param name="personalcontact">Students's contact</param>
        ///   <param name="guardiancontact">Parent or guardian's contact</param>
        ///    <param name="address">Student's Home address</param>
        public AdminProfileModel(string uri, string name, string powerid, string personalcontact, string guardiancontact, string address)
        {
            Initialize();

            Uri = uri;
            Name = name;
            PowerId = powerid;
            PersonalContact = personalcontact;
            GuardianContact = guardiancontact;
            Address = address;

        }
    }
}