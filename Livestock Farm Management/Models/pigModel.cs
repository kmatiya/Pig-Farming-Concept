using System.ComponentModel.DataAnnotations;
using Open_Chequelist_Template.Models;

namespace Livetock_Farm_Management.Models
{
    public class pigModel:pig, ISupplier
    {
        [Display(Name = "Supplier")]
        public string supplierID { get; set; }
        [Display(Name = "Name of Supplier")]
        public string supplierName { get; set; }
        [Display(Name = "Phone number of Supplier")]
        public string supplierPhoneNumber { get; set; }
        [Display(Name = "Email of Supplier")]
        public string supplierEmail { get; set; }
        [Display(Name = "Price bought")]
        public decimal buyingPrice { get ; set ; }
        [Display(Name = "Mother's Tag Number")]
        public string motherID { get; set; }
        [Display(Name = "Father's Tag Number")]
        public string fatherID { get; set; }
    }
}