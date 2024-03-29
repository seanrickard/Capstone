﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.MVC.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the role name")]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
