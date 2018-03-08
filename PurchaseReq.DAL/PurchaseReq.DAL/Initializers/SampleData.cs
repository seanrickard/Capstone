using PurchaseReq.DAL.EF;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Initializers
{
    public static class SampleData
    {
        //Done
        public static IEnumerable<Division> GetDivisions( List<Employee> Supervisors ) => new List<Division>
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
               SupervisorId =  Supervisors.Find(x => x.FirstName.ToString().Equals("Alice")).Id,
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
        public static IEnumerable<Department> GetDepartments( List<Division> Divisions ) => new List<Department>
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
        public static IEnumerable<Employee> GetEmployees => new List<Employee>
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

        //Done
        public static IEnumerable<Status> GetStatuses => new List<Status>
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
        public static IEnumerable<Vendor> GetVendors => new List<Vendor>
        { 
            new Vendor()
            {
                VendorName = "Amazon",
                Address = new Address{State = "CA", StreetAddress = "112 Amazon Dr.", City = "San Francisco", Zip = "26250"},
                Website = "www.amazon.com",
                Phone = "1-234-6489",
                Fax = "235456"
            },
            new Vendor()
            {
                VendorName = "Walmart",
                Address = new Address{State = "TX", StreetAddress = "Wally Street", City =  "Austin", Zip = "54689"},
                Website = "Walmart.com",
                Phone = "8-652-4523",
                Fax = "496832"
            },
            new Vendor()
            {
                VendorName = "Home Depot",
                Address = new Address{State = "WV", StreetAddress =  "Deposit Street", City = "Parkersburg", Zip = "25142"},
                Website = "HomeDepot.com",
                Phone = "1-304-8695",
                Fax = "579832"
            },
            new Vendor()
            {
                VendorName = "Computerland",
                Address = new Address{State = "WV", StreetAddress = "Land Street", City = "Charleston", Zip = "67513"},
                Website = "ComputerLand.com",
                Phone = "1-234-7564",
                Fax = "434863"
            },
            new Vendor()
            {
                VendorName = "Dollar General",
                Address = new Address{State = "WV", StreetAddress = "112 Brady Dr.", City = "Parkersburg", Zip = "25142"},
                Website = "www.dg.com",
                Phone = "1-456-4865",
                Fax = "215489"
            },
        };

        //Done
        public static IEnumerable<BudgetCode> GetBudgetCodes => new List<BudgetCode>
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
        public static IEnumerable<Category> GetCategories => new List<Category>
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

        public static IEnumerable<CFOApproval> GetCFOApprovals => new List<CFOApproval>
        {
            new CFOApproval()
            {
                ApprovalId = 4,
                OrderId = 2,
                CFOId = 1
            }
        };

        public static IEnumerable<SupervisorApproval> GetSupervisorApprovals( List<Employee> Supervisors ) => new List<SupervisorApproval>
        {
            new SupervisorApproval()
            {
                ApprovalId = 4,
                OrderId = 1,
                SupervisorId = Supervisors.Find(x => x.LastName.ToString().Equals("Gump")).Id,
            },
            new SupervisorApproval()
            {
                ApprovalId = 1,
                OrderId = 2,
                SupervisorId = Supervisors.Find(x => x.LastName.ToString().Equals("Gump")).Id,
            },
            new SupervisorApproval()
            {
                ApprovalId = 1,
                OrderId = 3,
                SupervisorId = Supervisors.Find(x => x.LastName.ToString().Equals("CFO")).Id,
            },
            new SupervisorApproval()
            {
                ApprovalId = 1,
                OrderId = 4,
                SupervisorId = Supervisors.Find(x => x.LastName.ToString().Equals("Frum")).Id,
            },
            new SupervisorApproval()
            {
                ApprovalId = 1,
                OrderId = 5,
                SupervisorId = Supervisors.Find(x => x.LastName.ToString().Equals("CFO")).Id,
            }
        };

        public static IEnumerable<EmployeesBudgetCodes> GetEmployeeBudgetCodes => new List<EmployeesBudgetCodes>
        {

        };

        public static IEnumerable<Attachment> GetAttachments() => new List<Attachment>
        {
            //add attachment info here
        };

        public static IEnumerable<Order> GetOrders( List<Employee> Employees ) => new List<Order>
        {
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Almond")).Id,
                StatusId = 1,
                CategoryId = 10,
                BudgetCodeId = 1,
                Ordered = false,
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Former materials need updated",
                DateMade = DateTime.Now
            },
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Thompson")).Id,
                StatusId = 2,
                CategoryId = 19,
                BudgetCodeId = 1,
                Ordered = false,
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Gotta have my berets",
                DateMade = DateTime.Now.AddDays(3)
            },
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Gump")).Id,
                StatusId = 4,
                CategoryId = 5,
                BudgetCodeId = 3,
                Ordered = true,
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Low on printer ink",
                DateMade = new DateTime(2018, 3, 1),
                DateOrdered = new DateTime(2018, 3, 7)
            },
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Heller")).Id,
                StatusId = 3,
                CategoryId = 1,
                BudgetCodeId = 3,
                Ordered = false,
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Textbooks for next semester",
                DateMade = new DateTime(2018, 3, 3)
            },
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Holland")).Id,
                StatusId = 1,
                CategoryId = 5,
                BudgetCodeId = 3,
                Ordered = false,
                Delivered = false,
                StateContract = false,
                BusinessJustification = "Snack foods",
                DateMade = new DateTime(2018, 2, 28)
            }
        };

        public static IEnumerable<Request> GetRequests => new List<Request>
        {
            new Request()
            {
                OrderId = 1,
                ItemId = 1, 
                VendorId = 1,
                QuantityRequested = 1,
                EstimatedCost = 1000.00m,
                EstimatedTotal = 1000.00m,
                Chosen = true
            },
            new Request()
            {
                OrderId = 2, 
                ItemId = 2, 
                VendorId = 1, 
                QuantityRequested = 365,
                EstimatedCost = 20.00m,
                EstimatedTotal = 7300.00m,
                ReasonChosen = "No other beret will suffice"
            },
            new Request()
            {
                OrderId = 2,
                ItemId = 6,
                VendorId = 1,
                QuantityRequested = 365,
                EstimatedCost = 19.00m,
                EstimatedTotal = 3650.00m,
                Chosen = false
            },
            new Request()
            {
                OrderId = 2,
                ItemId = 7,
                VendorId = 1,
                QuantityRequested = 365,
                EstimatedCost = 10.00m,
                EstimatedTotal = 3650.00m,
                Chosen = false
            },
            new Request()
            {
                OrderId = 3,
                ItemId = 3,
                VendorId = 2,
                QuantityRequested = 10,
                EstimatedCost = 1.00m,
                EstimatedTotal = 10.00m,
                PaidCost = .75m,
                PaidTotal = 7.50m,
                Chosen = true
            },
            new Request()
            {
                OrderId = 1,
                ItemId = 1,
                VendorId = 1,
                QuantityRequested = 1,
                EstimatedCost = 1000.00m,
                EstimatedTotal = 1000.00m,
                Chosen = true
            },
            new Request()
            {
                OrderId = 4,
                ItemId = 5,
                VendorId = 1,
                QuantityRequested = 5,
                EstimatedCost = 100.00m,
                EstimatedTotal = 500.00m,
                Chosen = true
            },
            new Request()
            {
                OrderId = 5,
                ItemId = 3,
                VendorId = 1,
                QuantityRequested = 20,
                EstimatedCost = 0.75m,
                EstimatedTotal = 15.00m,
                Chosen = true
            },
            new Request()
            {
                OrderId = 5,
                ItemId = 8,
                VendorId = 4,
                QuantityRequested = 3,
                EstimatedCost = 20.00m,
                EstimatedTotal = 60.00m,
                Chosen = true
            }
        };


        public static IEnumerable<Item> GetItems => new List<Item>
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
                Description = "A pencil"
            },
            new Item()
            {
                ItemName = "Marker",
                Description = "A marker that goes bad fast"
            },
            new Item()
            {
                ItemName = "Book",
                Description = "We don't pay enough for this"
            },
            new Item()
            {
                ItemName = "Off Brand Beret",
                Description = "A cheaper beret"
            },
            new Item()
            {
                ItemName = "Cowboy hat",
                Description = "yeehaw"
            },
            new Item()
            {
                ItemName = "HP Printing Paper",
                Description = "Good quality paper"
            }
        };

        public static IEnumerable<Approval> GetApprovals => new List<Approval>
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
            },
            new Approval()
            {
                ApprovalName = "Needing Approval"
            }
        };

        public static IEnumerable<Building> GetBuildings => new List<Building>
        {
            new Building()
            {
                Address = new Address{State = "WV", StreetAddress = "167 Nicolett Dr.", City = "Parkersburg", Zip = "25142"},
                BuildingName = "Main Campus"
            },
            new Building()
            {
                Address = new Address{State = "WV", StreetAddress = "105 Academy Dr.", City = "Ripley", Zip = "25271"},
                BuildingName = "Jackson County Center"
            }
        };

        public static IEnumerable<Room> GetRooms => new List<Room>
        {
            new Room()
            {
                BuildingId = 1,
                RoomCode = "A550"
            },
            new Room()
            {
                BuildingId = 1,
                RoomCode = "B220"
            },
            new Room()
            {
                BuildingId = 1,
                RoomCode = "C127"
            },
            new Room()
            {
                BuildingId = 2,
                RoomCode = "T651"
            }
        };
    }
}