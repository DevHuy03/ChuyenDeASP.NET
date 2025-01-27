﻿using Microsoft.AspNetCore.Mvc;
using Example04.Models;
using Example04.Context;
namespace Example04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeContext _companyContext;
        public EmployeeController(EmployeeContext companyContext)
        {
            _companyContext = companyContext;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _companyContext.Employees;
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _companyContext.Employees.FirstOrDefault(s => s.Id == id);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _companyContext.Employees.Add(value);
            _companyContext.SaveChanges();
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var employee = _companyContext.Employees.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _companyContext.Entry<Employee>(employee).CurrentValues.SetValues(value);
                _companyContext.SaveChanges();
            }
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
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