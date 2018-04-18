using Microsoft.AspNetCore.Identity;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Initializers
{
    public static class SampleData
    {
        //Done
        public static IEnumerable<Division> GetDivisions(List<Employee> Supervisors) => new List<Division>
        {

            new Division()
            {
               DivisionName = "Board of Governors",
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Alice")).Id,
            },
            new Division()
            {
               DivisionName = "STEM",
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Jared")).Id,
            },
            new Division()
            {
               DivisionName = "Nursing & Health Sciences",
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Kathy")).Id,
            },
            new Division()
            {
               DivisionName = "Education",
               SupervisorId = Supervisors.Find(x => x.FirstName.ToString().Equals("Jeffrey")).Id,
            },
            new Division()
            {
               DivisionName = "Business & Economics",
               SupervisorId =  Supervisors.Find(x => x.FirstName.ToString().Equals("Alice")).Id,
            },
        };

        //Done
        public static IEnumerable<Department> GetDepartments(List<Division> Divisions) => new List<Department>
        {
            new Department()
            {
                DepartmentName = "Purchase Department",
                Division = Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "IT Department",
                Division = Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "Business Office",
                Division = Divisions.Find(x => x.DivisionName.Equals("Business & Economics"))
            },
            new Department()
            {
                DepartmentName = "Nursing Department",
                Division = Divisions.Find(x => x.DivisionName.Equals("Nursing & Health Sciences"))
            },
            new Department()
            {
                DepartmentName = "Computer Science",
                Division =  Divisions.Find(x => x.DivisionName.Equals("STEM"))
            },
            new Department()
            {
                DepartmentName = "Math Department",
                Division = Divisions.Find(x => x.DivisionName.Equals("STEM"))
            },
            new Department()
            {
                DepartmentName = "Teaching Department",
                Division = Divisions.Find(x => x.DivisionName.Equals("Education"))
            },
            new Department()
            {
                DepartmentName = "Division Chairperson",
                Division = Divisions.Find(x => x.DivisionName.Equals("Board of Governors"))
            }
        };

        //Done
        //Users have sign in issues without a SecurityStamp -> https://stackoverflow.com/questions/29350167/how-to-create-a-security-stamp-value-for-asp-net-identity-iusersecuritystampsto
        public static IEnumerable<Employee> GetEmployees(List<Room> rooms) => new List<Employee>
        {
            new Employee()
            {
                FirstName = "Charles",
                LastName = "Almond",
                Email = "Almond@Develop.com",
                UserName = "Almond@Develop.com",
                NormalizedEmail = "ALMOND@DEVELOP.COM",
                NormalizedUserName = "ALMOND@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 3).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Gary",
                LastName = "Thompson",
                Email = "Thompson@Develop.com",
                UserName = "Thompson@Develop.com",
                NormalizedEmail = "THOMPSON@DEVELOP.COM",
                NormalizedUserName = "THOMPSON@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 3).FirstOrDefault()

            },
            new Employee()
            {
                FirstName = "Jared",
                LastName = "Gump",
                Email = "Gump@Develop.com",
                UserName = "Gump@Develop.com",
                NormalizedEmail = "GUMP@DEVELOP.COM",
                NormalizedUserName = "GUMP@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 1).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Kathy",
                LastName = "Frum",
                Email = "Frum@Develop.com",
                UserName = "Frum@Develop.com",
                NormalizedEmail = "FRUM@DEVELOP.COM",
                NormalizedUserName = "FRUM@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 2).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Julie",
                LastName = "Heller",
                Email = "Heller@Develop.com",
                UserName = "Heller@Develop.com",
                NormalizedEmail = "HELLER@DEVELOP.COM",
                NormalizedUserName = "HELLER@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 4).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "David",
                LastName = "Lancaster",
                Email = "Lancaster@Develop.com",
                UserName = "Lancaster@Develop.com",
                NormalizedEmail = "LANCASTER@DEVELOP.COM",
                NormalizedUserName = "LANCASTER@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 1).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Jeffrey",
                LastName = "Holland",
                Email = "Holland@Develop.com",
                UserName = "Holland@Develop.com",
                NormalizedEmail = "HOLLAND@DEVELOP.COM",
                NormalizedUserName = "HOLLAND@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 2).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Alice",
                LastName = "Harris",
                Email = "Harris@Develop.com",
                UserName = "Harris@Develop.com",
                NormalizedEmail = "HARRIS@DEVELOP.COM",
                NormalizedUserName = "HARRIS@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 2).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Auditor",
                LastName = "Auditor",
                Email = "Auditor@Develop.com",
                UserName = "Auditor@Develop.com",
                NormalizedEmail = "AUDITOR@DEVELOP.COM",
                NormalizedUserName = "AUDITOR@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new Employee()
            {
                FirstName = "Sue",
                LastName = "Purchase",
                Email = "Purchase@Develop.com",
                UserName = "Purchase@Develop.com",
                NormalizedEmail = "PURCHASE@DEVELOP.COM",
                NormalizedUserName = "PURCHASE@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Room = rooms.Where(x => x.Id == 2).FirstOrDefault()
            },
            new Employee()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "Admin@Develop.com",
                UserName = "Admin@Develop.com",
                NormalizedEmail = "ADMIN@DEVELOP.COM",
                NormalizedUserName = "ADMIN@DEVELOP.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            }
        };

        //Sets up employee department Id's after being in DB
        public static IEnumerable<Employee> SetEmployeesDepartment(List<Employee> employees)
        {
            int count = 1;
            employees.ForEach(x => {

                switch (count)
                {
                    //Alice and Sue
                    case 2:
                    case 11:
                        x.DepartmentId = 1;
                        break;
                    //Almond and Gary
                    case 4:
                    case 6:
                        x.DepartmentId = 5;
                        break;
                    //David, Gump, and Jeffrey
                    case 5:
                    case 7:
                    case 8:
                        x.DepartmentId = 8;
                        break;
                    //Julie and Kathy
                    case 9:
                    case 10:
                        x.DepartmentId = 4;
                        break;
                    default:
                        break;
                }

                count++;
            });

            return employees;
        }

        //Done
        public static IEnumerable<Status> GetStatuses => new List<Status>
        {
            new Status()
            {
                StatusName = "Created"
            },
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
                StatusName = "Approved"
            },
            new Status()
            {
                StatusName = "Ordered"
            },
            new Status()
            {
                StatusName = "Completed"
            },
            new Status()
            {
                StatusName = "Denied"
            },
            new Status()
            {
                StatusName = "Cancelled"
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
                BudgetAmounts = new List<BudgetAmount>{new BudgetAmount(){TotalAmount = 2000}}
            },
            new BudgetCode()
            {
                DA = 731180007,
                BudgetCodeName = "Nurse Budget",
                Type = true,
                BudgetAmounts = new List<BudgetAmount>{new BudgetAmount(){TotalAmount = 5500}, new BudgetAmount(){TotalAmount = 5000}}
            },
            new BudgetCode()
            {
                DA = 731180007,
                BudgetCodeName = "Backup Budget",
                Type = false,
                BudgetAmounts = new List<BudgetAmount>{new BudgetAmount(){TotalAmount = 7500}}
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


        public static IEnumerable<SupervisorApproval> GetSupervisorApprovals(List<Employee> Supervisors) => new List<SupervisorApproval>
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

        public static IEnumerable<EmployeesBudgetCodes> GetEmployeeBudgetCodes(List<Employee> employees, List<BudgetCode> codes) => new List<EmployeesBudgetCodes>
        {
            new EmployeesBudgetCodes()
            {
                Employee = employees.First(),
                BudgetCode = codes.First()
            },
            new EmployeesBudgetCodes()
            {
                Employee = employees[1],
                BudgetCode = codes.First()
            },
            new EmployeesBudgetCodes()
            {
                Employee = employees[3],
                BudgetCode = codes[1]
            },
            new EmployeesBudgetCodes()
            {
                Employee = employees[4],
                BudgetCode = codes[1]
            },
            new EmployeesBudgetCodes()
            {
                Employee = employees[2],
                BudgetCode = codes[2]
            },

        };

        public static IEnumerable<Attachment> GetAttachments() => new List<Attachment>
        {
            //add attachment info here
        };

        public static IEnumerable<Order> GetOrders(List<Employee> Employees) => new List<Order>
        {
            new Order()
            {
                EmployeeId = Employees.Find(x => x.LastName.ToString().Equals("Almond")).Id,
                StatusId = 1,
                CategoryId = 10,
                BudgetCodeId = 1,
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
                ApprovalName = "Approved"
            },
            new Approval()
            {
                ApprovalName = "Denied"
            }
        };

        public static IEnumerable<Campus> GetCampuses => new List<Campus>
        {
            new Campus()
            {
                Address = new Address{State = "WV", StreetAddress = "167 Nicolett Dr.", City = "Parkersburg", Zip = "25142"},
                CampusName  = "Main Campus"
            },
            new Campus()
            {
                Address = new Address{State = "WV", StreetAddress = "105 Academy Dr.", City = "Ripley", Zip = "25271"},
                CampusName = "Jackson County Center"
            }
        };

        public static IEnumerable<Room> GetRooms => new List<Room>
        {
            new Room()
            {
                CampusId = 1,
                RoomCode = "A550",
                RoomName = "Science Room"
            },
            new Room()
            {
                CampusId = 1,
                RoomCode = "B220",
                RoomName = "Creativity Room"
            },
            new Room()
            {
                CampusId = 1,
                RoomCode = "C127",
                RoomName = "Robotics Room"
            },
            new Room()
            {
                CampusId = 2,
                RoomCode = "T651",
                RoomName = "Fancy Office"
            }
        };

        public static IEnumerable<Employee> SetPasswords(List<Employee> employees)
        {
            PasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();

            foreach (var employee in employees)
            {
                employee.PasswordHash = passwordHasher.HashPassword(employee, "Develop@90");
            }

            return employees;
        }

        public static IEnumerable<IdentityRole> GetRoles => new List<IdentityRole>
        {
            new IdentityRole()
            {
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Name = "Purchasing",
                NormalizedName = "PURCHASING",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Name = "Auditor",
                NormalizedName = "AUDITOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Name = "CFO",
                NormalizedName = "CFO",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
        };

        public static IEnumerable<IdentityUserRole<string>> GetUserWithRole(List<Employee> users, List<IdentityRole> roles) => new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "User").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Almond").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "User").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Thompson").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Supervisor").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Gump").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Supervisor").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Frum").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "User").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Heller").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "User").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Lancaster").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Supervisor").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Holland").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "CFO").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Harris").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Auditor").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Auditor").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Purchasing").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Purchase").FirstOrDefault().Id
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles.Where(x => x.Name == "Admin").FirstOrDefault().Id,
                UserId = users.Where(x => x.LastName == "Admin").FirstOrDefault().Id
            },
        };
    }
}