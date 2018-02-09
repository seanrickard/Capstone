using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseReq.Models.Entities.Base;

namespace PurchaseReq.Models.Entities
{
    //adsfasdf
    [Table("Categories", Schema = "Order")]
    public class Category : EntityBase
    {   
        [DataType(DataType.Text), MaxLength(75)]
        public string CategoryName { get; set; }
    }
}
