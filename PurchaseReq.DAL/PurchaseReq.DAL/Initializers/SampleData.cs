using PurchaseReq.DAL.EF;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Initializers
{
    public static class SampleData
    {
        public static IEnumerable<Division> GetAllDivisions(PurchaseReqContext context) => new List<Division>
        {
            new Division()
            {
               DivisionName = "STEM",
               Active = true,
               SupervisorId = GetOneEmployee(context, 1).Id

                // need to figure out employee foreign key info
            }
        };
                   
        public static IEnumerable<Department> GetAllDepartments(PurchaseReqContext context) => new List<Department>
        {
            new Department()
            {
                DepartmentName = "Computer Science",
                Active = true,
            },
            new Department()
            {
                DepartmentName = "CIT",
                Active = true,
            }

        };

        public static IEnumerable<Employee> GetAllEmployees(PurchaseReqContext context) => new List<Employee>
        {
            new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                Active = true,
            },
            new Employee()
            {
                FirstName = "Chuck",
                LastName = "Almond",
                Active = true
            }
        };

        public static Employee GetOneEmployee(PurchaseReqContext context, int employeeId)
        {
            IEnumerable<Employee> employeeList = GetAllEmployees(context);
            List<Employee> empList = new List<Employee>();
            foreach(var emp in employeeList)
            {
               if (emp.Id == employeeId.ToString())
                {
                    return emp;
                }
            }
            return null;       
            

        }

        public static IEnumerable<Status> GetAllStatuses(PurchaseReqContext context) => new List<Status>
        {
            new Status()
            {
                StatusName = "Pending approval"
            },
            new Status()
            {
                StatusName = "Pending CFO approval"
            },
            new Status()
            {
                StatusName = "Ordered, waiting on delivery"
            }
           
        };

        public static IEnumerable<Approval> GetAllApprovals(PurchaseReqContext context) => new List<Approval>
        {
           new Approval()
           {
               ApprovalName = "Approved by CFO"               
           },
           new Approval()
           {
               ApprovalName = "Approved by Supervisor"
           },
           new Approval()
           {
               ApprovalName = "Denied"
           }
        };

        public static IEnumerable<Order> GetAllOrders(PurchaseReqContext context) => new List<Order>
        {
            new Order()
            {
                DateMade = DateTime.Now,
                Ordered = false,
                DateOrdered = DateTime.Now.AddDays(1),
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Need new computers for labs"
            }
        };

        public static IEnumerable<Request> GetAllRequests(PurchaseReqContext context) => new List<Request>
        {
            new Request()
            {
                QuantityRequested = 4,
                EstimatedCost = 4.99m,
                PaidCost = 5.75m,
                PaidTotal = 23.00m,
                Chosen = true
            },

            new Request()
            {
                QuantityRequested = 5,
                EstimatedCost = 101.00m,
                PaidCost = 105.56m,
                PaidTotal = 527.80m,
                Chosen = false
            }
        };

        public static IEnumerable<Vendor> GetAllVendors(PurchaseReqContext context) => new List<Vendor>
        {
            new Vendor()
            {
                VendorName = "Dollar General",
                Address = "112 Brady Dr.",
                State = "WV",
                City = "Parkersburg",
                Website = "www.dg.com",
                Zip = "25142",
            },

            new Vendor()
            {
                VendorName = "Amazon",
                Address = "112 Amazon Dr.",
                State = "CA",
                City = "San Francisco",
                Website = "www.amazon.com",
                Zip = "26250"
            }  
        };

        public static List<Item> GetItems(PurchaseReqContext context) => new List<Item>
        {
            new Item()
            {
                ItemName = "Computer",
                Description = "It's a computer, dummy"
                
            },
            new Item()
            {
                ItemName = "Mouse",
                Description = "Mouse for computer"
            },
            new Item()
            {
                ItemName = "Keyboard",
                Description = "Keyboard to type with on the computer"
            }
        };

        public static IEnumerable<Attachment> GetAllAttachments() => new List<Attachment>
        {
            //add attachment info here
        };

        public static IEnumerable<AlternativeRequest> GetAllAlternativeRequests = new List<AlternativeRequest>
        {
            //add info here
        };

        public static IEnumerable<BudgetCode> GetAllBudgetCodes => new List<BudgetCode>
        {
            //add info here
            new BudgetCode()
            {
                DA = 4

            }
        };

        public static IEnumerable<Category> GetAllCategories => new List<Category>
        {
            new Category()
            {
                CategoryName = "Computer Hardware"
            },
            new Category()
            {
                CategoryName = "Math Supplies"
            }
        };

        public static IEnumerable<CFO> GetAllCFOs => new List<CFO>
        {
            // add cfo info
        };

        public static IEnumerable<CFOApproval> GetAllCFOApprovals => new List<CFOApproval>
        {

        };

        public static IEnumerable<SupervisorApproval> GetAllSupervisorApprovals => new List<SupervisorApproval>
        {
            
        };

        public static IEnumerable<EmployeesBudgetCodes> GetAllEmployeeBudgetCodes => new List<EmployeesBudgetCodes>
        {

        };
    }
}