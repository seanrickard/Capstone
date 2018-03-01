using PurchaseReq.DAL.EF;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Initializers
{
    public static class SampleData
    {
        //Done
        public static IEnumerable<Division> GetDivisions(PurchaseReqContext context, List<Employee> Supervisors) => new List<Division>
        {

            new Division()
            {
               DivisionName = "Board of Governors",
               Active = true,
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Alice")).Id,
                // need to figure out employee foreign key info
            },
            new Division()
            {
               DivisionName = "STEM",
               Active = true,
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Jared")).Id,
               ParentId = 1
                // need to figure out employee foreign key info
            },
            new Division()
            {
               DivisionName = "Nursing & Health Sciences",
               Active = true,
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Kathy")).Id,
               ParentId = 1
                // need to figure out employee foreign key info
            },
            new Division()
            {
               DivisionName = "Education",
               Active = true,
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Jeffrey")).Id,
               ParentId = 1
                // need to figure out employee foreign key info
            },
            new Division()
            {
               DivisionName = "Business & Economics",
               Active = true,
               SupervisorId =  Supervisors.Find(x => x.FirstName.ToString().Equals("Julie")).Id,
               ParentId = 1
                // need to figure out employee foreign key info
            },
        };

        //public static Division GetOneDivision(PurchaseReqContext context) => new Division
        //{
          
        //       DivisionName = "STEM",
        //       Active = true,
        //       Supervisor = GetOneEmployee(context)

        //        // need to figure out employee foreign key info
            
        //};

        //Done
        public static IEnumerable<Department> GetDepartments(PurchaseReqContext context, List<Division> Divisions) => new List<Department>
        {
            new Department()
            {
                DepartmentName = "Purchase Department",
                Active = true,
                Division = Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "IT Department",
                Active = true,
                Division = Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "Business Office",
                Active = false,
                Division =Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "Nursing Department",
                Active = false,
                Division = Divisions.Find(x => x.DivisionName.Equals("Nursing & Health Sciences"))
            },
            new Department()
            {
                DepartmentName = "Computer Science",
                Active = false,
                Division =  Divisions.Find(x => x.DivisionName.Equals("STEM"))
            },
            new Department()
            {
                DepartmentName = "Math Department",
                Active = false,
                Division = Divisions.Find(x => x.DivisionName.Equals("STEM"))
            },
            new Department()
            {
                DepartmentName = "Teaching Department",
                Active = false,
                Division = Divisions.Find(x => x.DivisionName.Equals("Education"))
            },
            new Department()
            {
                DepartmentName = "Division Chairperson",
                Active = false,
                Division = Divisions.Find(x => x.DivisionName.Equals("Board of Governors"))
            }
        };

        //Done
        public static IEnumerable<Employee> GetEmployees(PurchaseReqContext context) => new List<Employee>
        {
            new Employee()
            {
                FirstName = "Charles",
                LastName = "Almond",
                Active = true,
            },
            new Employee()
            {
                FirstName = "Gary",
                LastName = "Thompson",
                Active = true
            },
            new Employee()
            {
                FirstName = "Jared",
                LastName = "Gump",
                Active = true
            },
            new Employee()
            {
                FirstName = "Kathy",
                LastName = "Frum",
                Active = true
            },
            new Employee()
            {
                FirstName = "Julie",
                LastName = "Heller",
                Active = true
            },
            new Employee()
            {
                FirstName = "David",
                LastName = "Lancaster",
                Active = true
            },
            new Employee()
            {
                FirstName = "Jeffrey",
                LastName = "Holland",
                Active = true
            },
            new Employee()
            {
                FirstName = "Alice",
                LastName = "CFO",
                Active = true
            }
        };

        //Sets up employee department Id's after being in DB
        public static IEnumerable<Employee> SetEmployeesDepartment(List<Employee> employees)
        {
            int count = 1;
            employees.ForEach(x => {
                
                switch(count)
                {
                    case 1:
                    case 2:
                        x.DepartmentId = 5;
                        break;
                    case 3:
                    case 6:
                    case 7:
                        x.DepartmentId = 8;
                        break;
                    case 4:
                    case 5:
                        x.DepartmentId = 4;
                        break;
                    case 8:
                        x.DepartmentId = 1;
                        break;
                    default:
                        break;
                }
            });

            return employees;
        }

        //public static Employee GetOneEmployee(PurchaseReqContext context) => new Employee
        //{
        //    FirstName = "Jane",
        //    LastName = "Doe",
        //    Active = true
        //};

        //Done
        public static IEnumerable<Status> GetStatuses(PurchaseReqContext context) => new List<Status>
        {
            new Status()
            {
                StatusName = "Waiting for Supervisor Approval"
            },
            new Status()
            {
                StatusName = "Waiting for CFO approval"
            },
            new Status()
            {
                StatusName = "Waiting to be Ordered"
            },
            new Status()
            {
                StatusName = "Ordered, waiting on delivery"
            },
            new Status()
            {
                StatusName = "Completed"
            }
        };

        //Done
        public static IEnumerable<Approval> GetAllApprovals(PurchaseReqContext context) => new List<Approval>
        {
           new Approval()
           {
               ApprovalName = "Approved by Supervisor"
           },
           new Approval()
           {
               ApprovalName = "Approved by CFO"               
           },
           new Approval()
           {
               ApprovalName = "Denied"
           }
        };
        

        //public static IEnumerable<Order> GetAllOrders(PurchaseReqContext context) => new List<Order>
        //{
        //    new Order()
        //    {
        //        DateMade = DateTime.Now,
        //        Ordered = false,
        //        DateOrdered = DateTime.Now.AddDays(1),
        //        Delivered = false,
        //        StateContract = false,
        //        BusinessJustification = "Need new computers for labs",
        //        Employee = SampleData.GetOneEmployee(context)
                
        //    }
        //};


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

        //Done
        public static IEnumerable<Vendor> GetAllVendors(PurchaseReqContext context) => new List<Vendor>
        {
            new Vendor()
            {
                VendorName = "Amazon",
                Address = "112 Amazon Dr.",
                State = "CA",
                City = "San Francisco",
                Website = "www.amazon.com",
                Zip = "26250",
                Phone = "1-234-6489",
                Fax = "235456"
            },
            new Vendor()
            {
                VendorName = "Walmart",
                Address = "Wally Street",
                State = "Texas",
                City = "Austin",
                Website = "Walmart.com",
                Zip = "54689",
                Phone = "8-652-4523",
                Fax = "496832"
            },
            new Vendor()
            {
                VendorName = "Home Depot",
                Address = "Deposit Street",
                State = "West Virginia",
                City = "Parkersburg",
                Website = "HomeDepot.com",
                Zip = "87654",
                Phone = "1-304-8695",
                Fax = "579832"
            },
            new Vendor()
            {
                VendorName = "Computerland",
                Address = "Land Street",
                State = "West Virginia",
                City = "Charleston",
                Website = "ComputerLand.com",
                Zip = "67513",
                Phone = "1-234-7564",
                Fax = "434863"
            },
            new Vendor()
            {
                VendorName = "Dollar General",
                Address = "112 Brady Dr.",
                State = "WV",
                City = "Parkersburg",
                Website = "www.dg.com",
                Zip = "25142",
                Phone = "1-456-4865",
                Fax = "215489"
            },

            
        };

        //Done
        public static List<Item> GetItems(PurchaseReqContext context) => new List<Item>
        {
            new Item()
            {
                ItemName = "Dell XPS 13",
                Description = "A sweet laptop"

            },
            new Item()
            {
                ItemName = "Basque Beret",
                Description = "A beret from the originators"
            },
            new Item()
            {
                ItemName = "Pencil",
                Description = "A Pencil"
            },
            new Item()
            {
                ItemName = "Marker",
                Description = "A marker that goes bad fast"
            },
             new Item()
            {
                ItemName = "Book",
                Description = "We don’t pay enough for this"
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

        //Done
        public static IEnumerable<BudgetCode> GetAllBudgetCodes => new List<BudgetCode>
        {
            //add info here
            new BudgetCode()
            {
                DA = 731180007,
                BudgetCodeName = "CS Budget",
                Type = true,
                Parent = 73118,
                Active = true,
                TotalAmount = 2000
            },
            new BudgetCode()
            {
                DA = 731180007,
                BudgetCodeName = "Nurse Budget",
                Type = true,
                Parent = 73118,
                Active = true,
                TotalAmount = 5000
            },
            new BudgetCode()
            {
                DA = 731180007,
                BudgetCodeName = "Backup Budget",
                Type = false,
                Parent = 73406,
                Active = true,
                TotalAmount = 7500
            },

        };

        //Done
        public static IEnumerable<Category> GetAllCategories => new List<Category>
        {
            new Category()
            {
                CategoryName = "Books and Periodicals"
            },
            new Category()
            {
                CategoryName = "Computer Supplies"
            },
            new Category()
            {
                CategoryName = "Computer Software - Less than $5,00"
            },
            new Category()
            {
                CategoryName = "Student Activities"
            },
            new Category()
            {
                CategoryName = "Office Expenses"
            },
            new Category()
            {
                CategoryName = "Other General Expenses"
            },
            new Category()
            {
                CategoryName = "Postage and Freight"
            },
            new Category()
            {
                CategoryName = "Printing and Binding"
            },
            new Category()
            {
                CategoryName = "Rent of Machines and Operating Leases"
            },
            new Category()
            {
                CategoryName = "Research and Educational Supplies"
            },
            new Category()
            {
                CategoryName = "Training and Development of Employees"
            },
            new Category()
            {
                CategoryName = "Travel - Within USA"
            },
            new Category()
            {
                CategoryName = "Vehicle Rental - Within USA"
            },
            new Category()
            {
                CategoryName = "Contractual and Professional Services"
            },
            new Category()
            {
                CategoryName = "Equipment less than $5,000 – Office and Communications"
            },
            new Category()
            {
                CategoryName = "Equipment less than $5,000 – Research and Educational"
            },
            new Category()
            {
                CategoryName = "Equipment less than $5,000 – Household and Furnishings"
            },
            new Category()
            {
                CategoryName = "Equipment greater than or equal to $5,000 – Office and Comm. "
            },
            new Category()
            {
                CategoryName = "Equipment greater than or equal to $5,000 – Household & Furnishings"
            },
                new Category()
            {
                CategoryName = "Equipment greater than or equal to $5,000 – Other Capital Equipment"
            },
            
        };


        //public static IEnumerable<CFO> GetAllCFOs => new List<CFO>
        //{
        //    // add cfo info
        //};

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