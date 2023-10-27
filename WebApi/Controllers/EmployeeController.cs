using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        //var response = new { message = "Not Found" };
        private readonly IEmployeeRepository<Employee> employeeRepository;
        public EmployeeController(EmployeeContext employeeContext, IEmployeeRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        //[HttpGet]
        //public IActionResult GetEmployees()
        //{
        //    return Ok(_employeeContext.Employees);
        //}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var employee = await employeeRepository.Get(id);
            if (employee != null)
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
            employeeRepository.Add(employee);
            return Ok(employee);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await employeeRepository.GetAll();
            if(result!=null) return Ok(result);
            var response = new { message = "Not Data found" };
            return NotFound();
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,Employee employee)
        {            
            var result = await employeeRepository.Update(id, employee);
            if (result != null) return Ok(result);
            return BadRequest();

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await employeeRepository.Delete(id);
            if (result != null) return Ok(result);
            var response = new { message = "Not Found" };
            return NotFound(response);
        }
    }
}
