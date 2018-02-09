using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("CFOs", Schema = "User")]
    public class CFO : EntityBase
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Key]
        [Column (Order = 2)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [InverseProperty(nameof(CFOApproval.CFO))]
        public List<CFOApproval> CFOApprovals { get; set; }
    }
}
