using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class DepartmentWithDivision : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        public int DivisionId { get; set; }

        [Display(Name = "Division")]
        public string DivisonName { get; set; }


    }
}
