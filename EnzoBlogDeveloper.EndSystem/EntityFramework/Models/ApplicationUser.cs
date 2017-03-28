using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.EndSystem.EntityFramework.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }

        [DisplayName("Disply Name")]
        public string DisplayName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; }
    }
}
