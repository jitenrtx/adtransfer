using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace adtransfer
{
    [NotMapped]
    public class PseudoClient : Client
    {

        public Client GetClient()
        {
            Client objClient = new Client();
            objClient.ClientID = this.ClientID;
            objClient.Name = this.Name;
            objClient.Address = this.Address;
            objClient.City = this.City;
            objClient.State = this.State;
            objClient.Country = this.Country;
            objClient.PinCode = this.PinCode;
            objClient.Status = this.Status != null ? this.Status : "True";
            objClient.DateCreated = DateTime.Now;
            return objClient;
        }
    }

    [MetadataType(typeof(ClientMetaData))]
    partial class Client
    {

    }
    internal sealed class ClientMetaData
    {
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
        public string PinCode { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "DateCreated")]
        public Nullable<System.DateTime> DateCreated { get; set; }

    }
}