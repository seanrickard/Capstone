﻿using Microsoft.EntityFrameworkCore;
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
        public IRequestRepo RequestRepo { get; }

        public OrderRepo(IRequestRepo requestRepo) : base()
        {
            RequestRepo = requestRepo;
        }

        internal PRWithRequest GetRecord(Employee user, Employee supervisor, Status status, Category c, BudgetCode bc, Order o)
        {
            //BusinessJustification & DateOrdered && CategoryId && BudgetCodeId
            var order = new PRWithRequest() {
                Id = o.Id,
                BusinessJustification = o.BusinessJustification,
                DateMade = o.DateMade,
                DateOrdered = o.DateOrdered,
                StateContract = o.StateContract,
                StatusId = status.Id,
                StatusName = status.StatusName,
            };

            var request = RequestRepo.GetAllForOrder(o.Id).ToList();

            if(request.Count > 0)
            {
                order.RequestsWithVendor = request;
            }

            if (o.TimeStamp != null)
            {
                    order.TimeStamp = o.TimeStamp;
            }

            if(user != null)
            {
                order.EmployeeFullName = user.FullName;
                order.EmployeeId = user.Id;
            }

            if(supervisor != null)
            {
                order.SupervisorId = supervisor.Id;
                order.SupervisorFullName = supervisor.FullName;
            }


            if(bc != null){
                order.BudgetCodeId = bc.Id;
                order.BudgetCodeName = bc.BudgetCodeName;
            }

            if(c != null){
                order.CategoryId = c.Id;
                order.CategoryName = c.CategoryName;
            }

            return order;
        }

        public IEnumerable<PRWithRequest> GetAllApproved()
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Approved")
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllApprovedForUser(string EmployeeId)
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Approved" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCompleted()
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Completed")
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCompletedForUser(string EmployeeId)
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Completed" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
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
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Ordered" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForCFO()
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Waiting for CFO approval")
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllWaitingForCFOForUser(string EmployeeId)
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Waiting for CFO approval" && x.EmployeeId == EmployeeId)
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
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

        public IEnumerable<PRWithRequest> GetAllDeniedBySupervisor(string supervisorId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Denied" && x.Employee.Department.Division.Supervisor.Id == supervisorId)
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

        internal IEnumerable<Order> QueryForSupervisorHistory() => Table.Include(x => x.Status)
                .Include(x => x.Category).Include(x => x.BudgetCode)
                .Include(x => x.SupervisorApprovals).ThenInclude(x => x.Employee)
                .Include(x => x.Employee);


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
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Denied")
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetDenied(string employeeId)
        {
            return QueryForSupervisorHistory()
                .Where(x => x.Status.StatusName == "Denied" && x.EmployeeId == employeeId)
                .Select(item => GetRecord(item.Employee, item.SupervisorApprovals.First().Employee, item.Status, item.Category, item.BudgetCode, item));
        }

        public IEnumerable<PRWithRequest> GetAllCancelled(string employeeId)
        {
            return QueryAll()
                .Where(x => x.Status.StatusName == "Cancelled" && x.EmployeeId == employeeId)
                .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }

        public PRWithRequest CancelOrder(int orderId)
        {
            Order order = Find(orderId);
            var CancellStatus = Context.Statuses.Where(x => x.StatusName == "Cancelled").FirstOrDefault();

            if (order.StatusId < CancellStatus.Id)
            {
                order.StatusId = CancellStatus.Id;
                Update(order);
            }

            return GetOrder(order.Id);
        }

        public IEnumerable<PRWithRequest> GetPendingForUser(string employeeId)
        {
            return QueryAll()
                    .Where(x => x.EmployeeId == employeeId).Where(x => x.Status.StatusName == "Waiting for Supervisor Approval" || x.Status.StatusName == "Waiting for CFO approval")
                    .Select(item => GetRecord(item.Employee, item.Employee.Department.Division.Supervisor, item.Status, item.Category, item.BudgetCode, item));
        }
    }
}
