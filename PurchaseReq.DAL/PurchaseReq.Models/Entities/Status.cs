using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseReq.Models.Entities.Base;

namespace PurchaseReq.Models.Entities
{
    [Table("Statuses", Schema = "Order")]
    public class Status : EntityBase
    {
        [DataType(DataType.Text), MaxLength(25)]
        public string StatusName { get; set; }
    }
}
