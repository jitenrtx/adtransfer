using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using adtransfer.Models;

namespace adtransfer
{
    [MetadataType(typeof(System_UserMetadata))]
    partial class System_User
    {
        public bool IsValid()
        {
            bool IsValid = false;
            using (var db = new adtransferContext())
            {
                System_User user = (from u in db.System_Users
                           where u.Email.Equals(this.Email)
                           && u.Password.Equals(this.Password)
                           select u).FirstOrDefault();
                //var blog = db.System_Users
                //    .Where(u => u.Email == this.Email && u.Password == this.Password)
                //    .FirstOrDefault();

                IsValid = user != null;
            }

            return IsValid;
        }
    }


    internal sealed class System_UserMetadata
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pass word is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
    }
}
