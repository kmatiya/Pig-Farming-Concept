//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Livetock_Farm_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class input
    {
        public int inputID { get; set; }
        public int product { get; set; }
        public decimal costPerProduct { get; set; }
        public int numberOfProducts { get; set; }
        public decimal total { get; set; }
        public System.DateTime date { get; set; }
        public int userID { get; set; }
        public int status { get; set; }
        public Nullable<int> pigID { get; set; }
    
        public virtual fieldState fieldState { get; set; }
        public virtual pig pig { get; set; }
        public virtual productType productType { get; set; }
        public virtual user user { get; set; }
    }
}
