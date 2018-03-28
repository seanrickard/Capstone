using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class DepartmentWithDivision : EntityBase
    {
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        public int DivisionId { get; set; }

        public Division Division { get; set; }

        public List<Division> Divisions { get; set; }
    }
}
