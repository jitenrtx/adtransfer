using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace adtransfer
{
    [NotMapped]
    public class PseudoBrand : Brand
    {
        public List<System.Web.Mvc.SelectListItem> client { get; set; }
        public List<System.Web.Mvc.SelectListItem> agency { get; set; }

        public Brand GetBrand()
        {
            Brand objManager = new Brand();
            objManager.ID = this.ID;
            objManager.Name = this.Name;
            objManager.Description = this.Description;
            objManager.ClientID = this.ClientID;
            objManager.AgencyID = this.AgencyID;
            objManager.BrandManagerID = this.BrandManagerID;
            objManager.AgencyManagerID = this.AgencyManagerID;
            return objManager;
        }

    }

    [MetadataType(typeof(BrandMetaData))]
    partial class Brand
    {
        
    }
    internal sealed class BrandMetaData
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

    public class ListBrand
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Client")]
        public string Client { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Agency")]
        public string Agency { get; set; }
    }

}