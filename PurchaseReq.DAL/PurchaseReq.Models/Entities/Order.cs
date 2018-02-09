using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Orders", Schema = "Order")]
    public class Order : EntityBase
    {

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

       
        public bool Ordered { get; set; }

        
        public bool DateOrdered { get; set; }

        
        public bool Delivered { get; set; }

        
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }
    }


}
