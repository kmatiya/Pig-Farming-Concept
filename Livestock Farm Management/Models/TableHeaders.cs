using System.ComponentModel.DataAnnotations;

namespace Livetock_Farm_Management.Models
{
    [MetadataType(typeof(PigMetaData))]
    public partial class pig
    {
    }
    public class PigMetaData
    {
        [Display(Name = "Pig Number")]
        public int pigNumber { get; set; }
        [Display(Name = "Tag Number")]
        public string tagNumber { get; set; }
        [Display(Name = "Sex")]
        public int pigSex { get; set; }
        [Display(Name = "Colour")]
        public string pigColor { get; set; }
        [Display(Name = "Brief Description")]
        public string description { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
        [Display(Name = "Source")]
        public int source { get; set; }
        [Display(Name = "Date of Acquisition")]
        public System.DateTime dateOfAcquisition { get; set; }
        [Display(Name = "Age in Years")]
        public string approximateAgeInYears { get; set; }
        [Display(Name = "Age in Months")]
        public string approximateAgeInMonths { get; set; }
    }
    [MetadataType(typeof(userMetaData))]
    public partial class user
    {

    }
    public class userMetaData
    {
        [Display(Name ="User ID")]
        public int userID { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Phone number")]
        public string phoneNumber { get; set; }
        [Display(Name = "Enail")]
        public string email { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Role")]
        public int role { get; set; }
    }
    public partial class sale
    {

    }
    public class saleMetaData
    {
        [Display(Name = "Sale ID")]
        public int salesID { get; set; }
        [Display(Name = "Pig Number")]
        public int pigNumber { get; set; }
        [Display(Name = "Selling Price")]
        public decimal price { get; set; }
        [Display(Name = "Date")]
        public System.DateTime salesDate { get; set; }
        [Display(Name = "Sold By")]
        public int userID { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
    }
    [MetadataType(typeof(pigSourceMetaData))]
    public partial class pigSource
    {

    }
    public class pigSourceMetaData
    {
        [Display(Name = "Source ID")]
        public int sourceID { get; set; }
        [Display(Name = "Source")]
        public string sourceName { get; set; }
    }
    [MetadataType(typeof(vaccinationMetaData))]
    public partial class vaccination
    {
    }
    public class vaccinationMetaData
    {
        [Display(Name ="Vaccine ID")]
        public int vaccinationID { get; set; }
        [Display(Name = "Vaccine Type")]
        public int type { get; set; }
        [Display(Name = "Pig Number")]
        public int pigNumber { get; set; }
        [Display(Name = "Date")]
        public System.DateTime date { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
    }
    [MetadataType(typeof(supplierMetaData))]
    public partial class supplier
    {

    }
    public class supplierMetaData
    {
        [Display(Name ="Supplier ID")]
        public int supplierID { get; set; }
        [Display(Name = "Supplier Name")]
        public string supplierName { get; set; }
        [Display(Name = "Phone Number")]
        public string supplierPhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string supplierEmail { get; set; }
        [Display(Name = "Status")]
        public int supplierState { get; set; }
    }
    [MetadataType(typeof(productTypeMetaData))]
    public partial class productType
    {

    }
    public class productTypeMetaData
    {
        [Display(Name ="Product ID")]
        public int productTypeID { get; set; }
        [Display(Name = "Product Type")]
        public string type { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
    }
    [MetadataType(typeof(inputMetaData))]
    public partial class input
    {

    }
    public class inputMetaData
    {
        [Display(Name ="Input ID")]
        public int inputID { get; set; }
        [Display(Name = "Product")]
        public int product { get; set; }
        [Display(Name = "Cost Per Product")]
        public decimal costPerProduct { get; set; }
        [Display(Name = "Number of Products")]
        public int numberOfProducts { get; set; }
        [Display(Name = "Total")]
        public decimal total { get; set; }
        [Display(Name = "Date")]
        public System.DateTime date { get; set; }
        [Display(Name = "User")]
        public int userID { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
    }
    [MetadataType(typeof(outSourcedPigMetaData))]
    public partial class outSourcedPig
    {

    }
    public class outSourcedPigMetaData
    {
        [Display(Name = "Out sourced Pig ID")]
        public int outSourcedPigID { get; set; }
        [Display(Name = "Pig Number")]
        public int pigNumber { get; set; }
        [Display(Name = "Supplier Name")]
        public int supplierID { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
    }
    [MetadataType(typeof(pigRelationshipMetaData))]
    public partial class pigRelationship
    {

    }
    public class pigRelationshipMetaData
    {
        [Display(Name = "Pig Relationship ID")]
        public int pigRelationshipID { get; set; }
        [Display(Name = "Female Pig")]
        public int femalePig { get; set; }
        [Display(Name = "Male Pig")]
        public int malePig { get; set; }
        [Display(Name = "Sibling")]
        public int siblings { get; set; }
    }
    [MetadataType(typeof(vaccineTypeMetaData))]
    public partial class vaccineType
    {

    }
    public class vaccineTypeMetaData
    {
        [Display(Name ="Vaccine Type ID")]
        public int vaccineTypeID { get; set; }
        [Display(Name = "Vaccine Type")]
        public string typeOfVaccine { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
    }
    [MetadataType(typeof(systemRoleMetaData))]
    public partial class systemRole
    {

    }
    public class systemRoleMetaData
    {
        [Display(Name = "Role ID")]
        public int systemRoleID { get; set; }
        [Display(Name = "Role")]
        public string roleName { get; set; }
    }
    public partial class fieldState
    {

    }
    public class fieldStateMetaData
    {
        [Display(Name = "Field ID")]
        public int fieldStatusID { get; set; }
        [Display(Name = "States")]
        public string state { get; set; }
    }
}