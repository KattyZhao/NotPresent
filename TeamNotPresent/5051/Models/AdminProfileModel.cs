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
        [Display(Name = "Student ID", Description = "Student's School Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Display(Name = "Uri", Description = "Picture to Show")]
        [Required(ErrorMessage = "Picture is required")]
        public string Uri { get; set; }

        [Display(Name = "Name", Description = "Student Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Power ID", Description = "Scholl's Previous System ID")]
        [Required(ErrorMessage = "PowerId is required")]
        public string PowerId { get; set; }

        [Display(Name = "Student Contact", Description = "Personal Phone Number")]
        [Required(ErrorMessage = "Student Contact is required")]
        public string PersonalContact { get; set; }

        [Display(Name = "Guardian Contact", Description = "Parent's Phone Number")]
        [Required(ErrorMessage = "Guardian Contact is required")]
        public string GuardianContact { get; set; }

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
        /// New Avatar
        /// </summary>
        public AdminProfileModel()
        {
            Initialize();
        }

        /// <summary>
        /// Make an Avatar from values passed in
        /// </summary>
        /// <param name="uri">The Picture path</param>
        /// <param name="name">Avatar Name</param>
        /// <param name="description">Avatar Description</param>
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