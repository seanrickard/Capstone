using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class PasswordEmployeeViewModel : EmployeeWithDepartmentAndRoomAndRole
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
