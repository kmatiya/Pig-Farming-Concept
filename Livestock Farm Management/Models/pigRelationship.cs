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
    
    public partial class pigRelationship
    {
        public int pigRelationshipID { get; set; }
        public Nullable<int> femalePig { get; set; }
        public Nullable<int> malePig { get; set; }
        public int siblings { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual fieldState fieldState { get; set; }
        public virtual pig pig { get; set; }
        public virtual pig pig1 { get; set; }
        public virtual pig pig2 { get; set; }
    }
}