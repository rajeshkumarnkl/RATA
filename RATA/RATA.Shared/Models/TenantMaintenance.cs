using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RATA.Shared.Models
{
    public class TenantMaintenance
    {
        public int ID { get; set; }
        public int TenantID { get; set; }
        public string Month { get; set; }
        public decimal WaterBill { get; set; }
        public decimal Maintenance { get; set; }
        //public virtual Tenant Tenant { get; set; }
    }
}
