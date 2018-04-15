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
        internal PRWithRequest GetRecord(Employee user, Employee supervisor, Status status, Category c, BudgetCode bc, Order o) => new PRWithRequest
        {
            BudgetCodeId = bc.Id,
            BudgetCodeName = bc.BudgetCodeName,
            
            Id = o.Id, 
            BusinessJustification = o.BusinessJustification,
            DateMade = o.DateMade,
            DateOrdered = o.DateOrdered,
            StateContract = o.StateContract,
            TimeStamp = o.TimeStamp,

            CategoryId = c.Id,
            CategoryName = c.CategoryName,

            EmployeeFullName = user.FullName,
            EmployeeId = user.Id,

            StatusId = status.Id,
            StatusName = status.StatusName,

            SupervisorId = supervisor.Id,
            SupervisorFullName = supervisor.FullName,
        };

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

        public PRWithRequest GetNewOrder(string EmployeeId)
        {
            throw new System.NotImplementedException();
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

            //var order = Table.SingleOrDefault(x => x.Id == id);

            //var user = Context.Employees.Include(x => x.Department).ThenInclude(x => x.Division).ThenInclude(x => x.Supervisor).SingleOrDefault(x => x.Id == order.EmployeeId);

            //var supervisor = Context.Employees.SingleOrDefault(x => x.Id == user.Department.Division.Supervisor.Id);

            //var status = Context.Statuses.SingleOrDefault(x => order.StatusId == x.Id);

            //var category = Context.Categories.SingleOrDefault(x => x.Id == order.CategoryId);

            //var budget = Context.BudgetCodes.SingleOrDefault(x => x.Id == order.BudgetCodeId);

            //return GetRecord(user, supervisor, status, category, budget, order);
        }
        public PRWithRequest MoveToTheNextLifeCycle(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PRWithRequest> GetAllOrdered()
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Ordered")
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }
    }
}
