﻿using PurchaseReq.Models.Entities;
using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class PRWithRequest : EntityBase
    {
        public Status Status { get; set; }

        public int StatusId { get; set; }

        public Category Category { get; set; }

        public BudgetCode BudgetCode { get; set; }

        public int BudgetCodeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

        public List<RequestWithVendor> RequestsWithVendor { get; set; } = new List<RequestWithVendor>();
    }
}
