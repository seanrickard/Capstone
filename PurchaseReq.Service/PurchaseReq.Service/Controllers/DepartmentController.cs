﻿using Microsoft.AspNetCore.Mvc;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;

namespace PurchaseReq.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _repo;

        public DepartmentController(IDepartmentRepo addressRepo)
        {
            _repo = addressRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllWithDivision().Where(x => x.Active));
        }
        [HttpGet]
        public IActionResult GetInactive()
        {
            return Ok(_repo.GetAllWithDivision().Where(x => !x.Active));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repo.GetDepartmentWithDivision(id);
            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpGet("{divisionId}")]
        public IActionResult GetByDivision(int divisionId)
        {
            //Refactor Later
            return Ok(_repo.GetAllWithDivision().Where(x => x.DivisionId == divisionId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Department model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Add(model);
            return CreatedAtAction("Create", model);
        }

        [HttpPut("{departmentId}")]
        public IActionResult Update(int departmentId, [FromBody] Department model)
        {
            if (model == null || departmentId != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Update(model);
            return CreatedAtAction("Update", model);
        }
    }
}
