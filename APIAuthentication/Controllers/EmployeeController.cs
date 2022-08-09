using APIAuthentication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _companyContext;
        public EmployeeController(ApplicationDbContext databaseContext)
        {
            _companyContext = databaseContext;
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public IEnumerable<Employee> Get()
        {
            return _companyContext.Employees.ToList();
        }
        [HttpGet("GetByID{id}")]
        public Employee Get(int id)
        {
            return _companyContext.Employees.FirstOrDefault(s => s.Id == id);
        }
        [HttpPost]
        [Route("AddNewEmployee")]
        public void Post([FromBody] Employee value)
        {
            if(value != null)
            {
                _companyContext.Employees.Add(value);
            }
            _companyContext.SaveChanges();
        }
        [HttpPut("UpdateEmployee/{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var employee = _companyContext.Employees.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                employee.Name = value.Name;
                employee.Age = value.Age;
                employee.CompanyName = value.CompanyName;
                employee.City = value.City;
                employee.Address = value.Address;
                employee.Salary = value.Salary;
                employee.Email = value.Email;
                _companyContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _companyContext.SaveChanges();
            }
        }
        [HttpDelete("DeleteEmployee{id}")]
        public void Delete(int id)
        {
            var student = _companyContext.Employees.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _companyContext.Employees.Remove(student);
                _companyContext.SaveChanges();
            }
        }
    }
}
