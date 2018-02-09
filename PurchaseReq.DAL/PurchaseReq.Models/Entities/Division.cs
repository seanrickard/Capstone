using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Divisions", Schema = "User")]
    public class Division : EntityBase
    {
        [DataType(DataType.Text)]
        public string DivisionName { get; set; }

        public bool Active { get; set; }

    }
}
