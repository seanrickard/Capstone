using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
