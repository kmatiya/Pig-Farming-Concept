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
    
    public partial class productType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productType()
        {
            this.inputs = new HashSet<input>();
        }
    
        public int productTypeID { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int status { get; set; }
    
        public virtual fieldState fieldState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<input> inputs { get; set; }
    }
}
