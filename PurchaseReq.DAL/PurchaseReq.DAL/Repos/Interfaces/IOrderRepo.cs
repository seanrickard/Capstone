using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using PurchaseReq.Models.ViewModels;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        PRWithRequest GetOrder(int? id);

        IEnumerable<PRWithRequest> GetAllForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllCreatedForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllWaitingForSupervisorForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllWaitingForCFOForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllApprovedForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllOrderedForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllCompletedForUser(string EmployeeId);

        IEnumerable<PRWithRequest> GetAllWaitingForSupervisor();

        IEnumerable<PRWithRequest> GetAllWaitingForSupervisor(string supervisorId);

        IEnumerable<PRWithRequest> GetAllWaitingForCFO();

        IEnumerable<PRWithRequest> GetAllOrdered();

        IEnumerable<PRWithRequest> GetAllCompleted();

        IEnumerable<PRWithRequest> GetAllApproved();

        //Create a new Order and return the viewModel
        PRWithRequest GetNewOrder(string EmployeeId);

        //Moves the Order to the Next stage of the life cycle
        //Increment status ID by 1

        IEnumerable<PRWithRequest> GetAllCancelled(string employeeId);

        PRWithRequest MoveToTheNextLifeCycle(int id);

        PRWithRequest MoveToCFOStatus(int orderId);

        PRWithRequest DenyOrder(int orderId);

        PRWithRequest CancelOrder(int orderId);

        IEnumerable<PRWithRequest> GetDenied();

        IEnumerable<PRWithRequest> GetDenied(string employedId);

        //Meaning both Waiting for Supervisor and CFO
        IEnumerable<PRWithRequest> GetPendingForUser(string employeeId);

    }
}
