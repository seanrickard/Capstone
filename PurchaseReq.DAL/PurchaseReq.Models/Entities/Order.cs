using PurchaseReq.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseReq.Models.Entities
{
    [Table("Orders", Schema = "Order")]
    public class Order : EntityBase
    {

        [DataType(DataType.Date)]
        public DateTime DateMade { get; set; }

       
        public bool Ordered { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOrdered { get; set; }

        
        public bool Delivered { get; set; }

        
        public bool StateContract { get; set; }

        [DataType(DataType.MultilineText)]
        public string BusinessJustification { get; set; }

        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status Status { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category{ get; set; }

        //In case no work
        //[InverseProperty(nameof(SupervisorApproval.Order))]
        public SupervisorApproval SupervisorApproval { get; set; }

        public CFOApproval CFOApproval { get; set; }

        [InverseProperty(nameof(Request.Order))]
        public List<Request> Requests { get; set; }

        public int BudgetCodeId { get; set; }

        [ForeignKey(nameof(BudgetCodeId))]
        public BudgetCode BudgetCode { get; set; }


    }


}
