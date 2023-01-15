﻿using RestApiNew.Models;
using System;
using System.Collections.Generic;

namespace RestApiNew.EmployeeData
{
     public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee EditEmployee(Employee employee);
    }
}
