using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace adtransfer
{
    [NotMapped]
    public class PseudoBrandManager : BrandManager {

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public BrandManager GetBrandManager()
        {
            BrandManager objManager = new BrandManager();
            objManager.BrandManagerID = this.BrandManagerID;
            objManager.ClientID = this.ClientID;
            objManager.Name = this.Name;
            objManager.Address = this.Address;
            objManager.City = this.City;
            objManager.State = this.State;
            objManager.Country = this.Country;
            objManager.PINCode = this.PINCode;
            objManager.Email = this.Email;
            objManager.Phone = this.Phone;
            objManager.Password = this.Password;
            objManager.type = this.type;
            objManager.Status = this.Status == null ? objManager.Status : true;
            return objManager;
        }

    }


    [MetadataType(typeof(BrandManagerMetaData))]
    partial class BrandManager
    {

    }
    internal sealed class BrandManagerMetaData
    {
        [Required]
        [Display(Name = "BrandManagerID")]
        public int BrandManagerID { get; set; }

        [Required]
        [Display(Name = "ClientID")]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        [Display(Name = "PinCode")]
        public string PINCode { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}