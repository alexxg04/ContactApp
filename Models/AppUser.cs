using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using ContactApp.Enums;




namespace ContactApp.Models
{
    //this is looking at the Icollection Contacts on the AppUser Model
  //  AppUser appUser = _context.Users
    //.Include(c => c.Contacts)

    //this is looking at the Icollection categories on the contacts model. ThenInclude //references the model in the previous include statement which in this case is // // //contacts.
//    .ThenInclude(c => c.Categories)

    //takes the first match
  //  .FirstOrDefault(u => u.Id == appUserId);

    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        //allows a user to include its related contacts
       // public virtual ICollection Contacts { get; set; } = new HashSet();

        public virtual ICollection<Contact> Contact { get; set; } = new HashSet<Contact>();


        //allows a user to include its related categories
        /// <summary>
        /// public virtual ICollection Categories { get; set; } = new HashSet();
        /// </summary>



        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    }
}