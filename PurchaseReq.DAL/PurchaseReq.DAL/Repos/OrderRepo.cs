using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseReq.DAL.Repos
{
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        internal PRWithRequest GetRecord(Employee user, Employee supervisor, Status status, Category c, BudgetCode bc, Order o)
        {
            //BusinessJustification & DateOrdered && CategoryId && BudgetCodeId
            var request = new PRWithRequest() {
                Id = o.Id,
                BusinessJustification = o.BusinessJustification,
                DateMade = o.DateMade,
                DateOrdered = o.DateOrdered,
                StateContract = o.StateContract,
                StatusId = status.Id,
                StatusName = status.StatusName,
            };

            if(o.TimeStamp != null)
            {
                request.TimeStamp = o.TimeStamp;
            }

            if(user != null)
            {
                request.EmployeeFullName = user.FullName;
                request.EmployeeId = user.Id;
            }

            if(supervisor != null)
            {
                request.SupervisorId = supervisor.Id;
                request.SupervisorFullName = supervisor.FullName;
            }


            if(bc != null){
                request.BudgetCodeId = bc.Id;
                request.BudgetCodeName = bc.BudgetCodeName;
            }

            if(c != null){
                request.CategoryId = c.Id;
                request.CategoryName = c.CategoryName;
            }

            return request;
        }

        public IEnumerable<PRWithRequest> GetAllApproved()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Approved")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllApprovedForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Approved" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCompleted()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Completed")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCompletedForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Completed" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCreatedForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Created" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllOrderedForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Ordered" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForCFO()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Waiting for CFO approval")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForCFOForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Waiting for CFO approval" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForSupervisor()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Waiting for Supervisor Approval")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForSupervisor(string supervisorId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Waiting for Supervisor Approval" && x.Employee.Department.Division.Supervisor.Id == supervisorId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForSupervisorForUser(string EmployeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Waiting for Supervisor Approval" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }




        internal IEnumerable<Order> QueryAll() => Table.Include(x => x.Status)
                .Include(x => x.Category).Include(x => x.BudgetCode)
                .Include(x => x.Employee).ThenInclude(x => x.Department)
                .ThenInclude(x => x.Division)
                .ThenInclude(x => x.Supervisor);


        public PRWithRequest GetOrder(int? id)
        {
            ////Got alot of includes to get to the Employees Supervisor
            return QueryAll()
            .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item))
            .SingleOrDefault(x => x.Id == id);
        }


        public IEnumerable<PRWithRequest> GetAllOrdered()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Ordered")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        //Start Functionality methods

        public PRWithRequest GetNewOrder(string EmployeeId)
        {
            Order newOrder = new Order();
            newOrder.StatusId = Context.Statuses.Where(x => x.StatusName == "Created").FirstOrDefault().Id;
            newOrder.EmployeeId = EmployeeId;
            Add(newOrder);

            return GetOrder(newOrder.Id);
        }

        public PRWithRequest MoveToTheNextLifeCycle(int id)
        {
            Order order = Find(id);
            var Status = Context.Statuses.Find(order.StatusId);
            if (Status.StatusName == "Waiting for Supervisor Approval")
            {
                order.StatusId = order.StatusId + 2;
            }
            else if(Status.StatusName == "Denied")
            {
                //Do Nothing
                //Should never happen but defensive programming incase
            }
            else
            {
                order.StatusId = order.StatusId + 1;
            }

            Update(order);
            return GetOrder(order.Id);
        }

        public PRWithRequest MoveToCFOStatus(int orderId)
        {
            Order order = Find(orderId);
            var CFOStatus = Context.Statuses.Where(x => x.StatusName == "Waiting for CFO approval").FirstOrDefault();

            if (order.StatusId < CFOStatus.Id)
            {
                order.StatusId = CFOStatus.Id;
                Update(order);
            }

            return GetOrder(order.Id);
        }

        public PRWithRequest DenyOrder(int orderId)
        {
            Order order = Find(orderId);
            var DenyStatus = Context.Statuses.Where(x => x.StatusName == "Denied").FirstOrDefault();

            if (order.StatusId < DenyStatus.Id)
            {
                order.StatusId = DenyStatus.Id;
                Update(order);
            }

            return GetOrder(order.Id);
        }

        public IEnumerable<PRWithRequest> GetDenied()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Denied")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetDenied(string employeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Denied" && x.EmployeeId == employeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }
    }
}
