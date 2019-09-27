using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Chequelist_Template.Models
{
    interface ISupplier
    {
        string supplierID { get; set; }
        string supplierName { get; set; }
        string supplierPhoneNumber { get; set; }
        string supplierEmail { get; set; }
    }
}
