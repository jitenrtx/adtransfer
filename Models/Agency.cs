using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace adtransfer
{
    [NotMapped]
    public class PseudoAgency : Agency
    {
        public Agency GetAgency()
        {
            Agency objAgency = new Agency();
            objAgency.AgencyID = this.AgencyID;
            objAgency.Name = this.Name;
            objAgency.Address = this.Address;
            objAgency.City = this.City;
            objAgency.State = this.State;
            objAgency.Country = this.Country;
            objAgency.PIN = this.PIN;
            return objAgency;
        }

    }


    [MetadataType(typeof(objAgencyMetaData))]
    partial class objAgency
    {

    }
    internal sealed class objAgencyMetaData
    {
        [Required]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "ClientID")]
        public int ClientID { get; set; }


        [Required]
        [Display(Name = "AgencyID")]
        public int AgencyID { get; set; }

        [Required]
        [Display(Name = "BrandManagerID")]
        public int BrandManagerID { get; set; }

        [Required]
        [Display(Name = "AgencyManagerID")]
        public int AgencyManagerID { get; set; }
    }
}