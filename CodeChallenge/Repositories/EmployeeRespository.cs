using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository2
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository2> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository2> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            // Employee.DirectReports is always null using the original implementation.
            // return _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == id);

            // This implementation returns an Employee with proper DirectReports
            return _employeeContext.Employees.ToList().SingleOrDefault(e => e.EmployeeId == id);
        }

        public Compensation Add(Compensation compensation)
        {
            compensation.Id = Guid.NewGuid().ToString();
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetCompensationById(string id)
        {
            var result =  _employeeContext.Compensations.SingleOrDefault(c => c.employee.EmployeeId == id);

            // Similar to GetById(), the query above always returns Compoensation.employee as null
            // This sets employee to a valid value.
            result.employee = _employeeContext.Employees.ToList().SingleOrDefault(e => e.EmployeeId == id);
            return result;
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }

        public Compensation Remove(Compensation compensation)
        {
            return _employeeContext.Remove(compensation).Entity;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
