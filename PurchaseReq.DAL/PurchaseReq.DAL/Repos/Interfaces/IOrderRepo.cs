﻿using PurchaseReq.DAL.Repos.Base;
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

        //Create a new Order and return the viewModel
        PRWithRequest GetNewOrder(string EmployeeId);

        //Moves the Order to the Next stage of the life cycle
        //Increment status ID by 1
        PRWithRequest MoveToTheNextLifeCycle(int id);


    }
}
