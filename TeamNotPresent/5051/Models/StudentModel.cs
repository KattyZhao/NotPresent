
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using _5051.Backend;

namespace _5051.Models
{
    /// <summary>
    /// The Student, this holds the student id, name, tokens.  Other things about the student such as their attendance is pulled from the attendance data, or the owned items, from the inventory data
    /// </summary>
    public class StudentModel
    {
        /// <summary>
        /// The ID for the Student, this is the key, and a required field
        /// </summary>
        [Key]
        [Display(Name = "Id", Description = "Student Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

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
        /// The number of Tokens the student has, tokens are used in the store, and also to level up
        /// </summary>
        [Display(Name = "Tokens", Description = "Tokens Saved")]
        [Required(ErrorMessage = "Tokens are required")]
        public int Tokens { get; set; }

        /// <summary>
        /// Katty update this 
        /// </summary>
        [Display(Name = "Cities", Description = "Cities Purchaged")]
        public int Cities { get; set; }

        /// <summary>
        /// The defaults for a new student
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
            Tokens = 100;
            Cities = 0;
        }

        /// <summary>
        /// Constructor for a student
        /// </summary>
        public StudentModel()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor for Student.  Call this when making a new student
        /// </summary>
        /// <param name="name">The Name to call the student</param>
        /// <param name="studentId">The avatar to use, if not specified, will call the backend to get an ID</param>
        public StudentModel(string name, string studentId)
        {
            Initialize();

            Name = name;

            
        }

        /// <summary>
        /// Convert a Student Display View Model, to a Student Model, used for when passed data from Views that use the full Student Display View Model.
        /// </summary>
        /// <param name="data">The student data to pull</param>
        public StudentModel(StudentDisplayViewModel data)
        {
            

            Id = data.Id;
            Name = data.Name;
            PowerId = data.PowerId;
            PersonalContact = data.PersonalContact;
            GuardianContact = data.GuardianContact;
            Address = data.Address;
            Tokens = data.Tokens;
            Cities = data.Cities;
        }

        /// <summary>
        /// Update the Data Fields with the values passed in, do not update the ID.
        /// </summary>
        /// <param name="data">The values to update</param>
        /// <returns>False if null, else true</returns>
        public bool Update(StudentModel data)
        {
            if (data == null)
            {
                return false;
            }

            Name = data.Name;
            PowerId = data.PowerId;
            PersonalContact = data.PersonalContact;
            GuardianContact = data.GuardianContact;
            Address = data.Address;

            return true;
        }
    }

    /// <summary>
    /// For the Index View, add the Avatar URI to the Student, so it shows the student with the picture
    /// </summary>
    public class StudentDisplayViewModel : StudentModel
    {
        /// <summary>
        /// The path to the local image for the avatar
        /// </summary>
        [Display(Name = "Student Picture", Description = "Student Picture to Show")]
        public string DisplayPicture { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public StudentDisplayViewModel() { }

        /// <summary>
        /// Creates a Student Display View Model from a Student Model
        /// </summary>
        /// <param name="data">The Student Model to create</param>
        public StudentDisplayViewModel(StudentModel data)
        {
            Id = data.Id;
            Name = data.Name;
            PowerId = data.PowerId;
            PersonalContact = data.PersonalContact;
            GuardianContact = data.GuardianContact;
            Address = data.Address;
        }
    }
}