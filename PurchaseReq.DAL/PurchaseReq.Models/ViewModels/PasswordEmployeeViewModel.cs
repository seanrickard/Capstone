using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class PasswordEmployeeViewModel : EmployeeWithDepartmentAndRoomAndRole
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
