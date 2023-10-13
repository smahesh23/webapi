using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext; 
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeContext.Employees);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSingleEmployee([FromRoute] int id)
        {
            var employee = _employeeContext.Employees.Find(id);
            if(employee != null) 
            {
                return Ok(employee);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployee addEmployee)
        {
            var employee = new Employee()
            {
                Name = addEmployee.Name,
                Phone = addEmployee.Phone,
                Company = addEmployee.Company,
                Role = addEmployee.Role,
                City = addEmployee.City
            };
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute] int id, AddEmployee updateEmployee)
        {
            var employee = _employeeContext.Employees.Find(id);
            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Phone = updateEmployee.Phone;
                employee.Company = updateEmployee.Company;
                employee.Role = updateEmployee.Role;
                _employeeContext.SaveChanges();
                return Ok(employee);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute]int id)
        {
            var employee=_employeeContext.Employees.Find(id);
            if(employee != null)
            {
                _employeeContext.Employees.Remove(employee);
                _employeeContext.SaveChanges();
                return Ok(employee);
            }
            return NotFound();
        }
    }
}
