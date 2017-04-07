using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace DapperEx.Web.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("User ID")]
        public string USERID { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string USER_PSWD { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LASTNAME { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FIRSTNAME { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string EMAIL { get; set; }

        public DateTime PSWD_EXPIRE { get; set; }
    }
}