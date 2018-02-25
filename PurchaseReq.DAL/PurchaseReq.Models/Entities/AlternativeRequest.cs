using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace PurchaseReq.Models.Entities
{
    [Table("AlternativeRequest", Schema = "Order")]
    public class AlternativeRequest : EntityBase
    {
        public int RequestId {get; set;}

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        public int AlternativeId { get; set; }

        [ForeignKey(nameof(AlternativeId))]
        public Request Alternative { get; set; }

    }
}
