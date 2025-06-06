﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiNew.EmployeeData;
using RestApiNew.Models;
using System;


namespace RestApiNew.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id : {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id : {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var ExistingEmployee = _employeeData.GetEmployee(id);
            if (ExistingEmployee != null)
            {
                employee.Id = ExistingEmployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}
