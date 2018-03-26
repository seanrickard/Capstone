using PurchaseReq.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PurchaseReq.Models.ViewModels
{
    public class PRForm
    {
        public Status Status { get; set; }

        public int StatusId { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public BudgetCode BudgetCode { get; set; }

        public int BudgetCodeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

    }
}
