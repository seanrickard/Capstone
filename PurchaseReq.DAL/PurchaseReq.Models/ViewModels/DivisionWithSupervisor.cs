﻿using PurchaseReq.Models.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class DivisionWithSupervisor : EntityBase
    {
        [DataType(DataType.Text)]
        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public string SupervisorId { get; set; }

        [Display(Name = "Supervisor")]
        public string SupervisorName { get; set; }
    }
}
