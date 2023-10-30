using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using DataAccessLayer.DatabaseModels;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeService<Employee> _employeeService;
        public EmployeeController(IEmployeeService<Employee> employeeService)
        {
            this._employeeService = employeeService;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var employee = await _employeeService.Get(id);
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
            _employeeService.Add(employee);
            return Ok(employee);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            Console.WriteLine("From Microservices");
            var result = await _employeeService.GetAll();
            if(result!=null) return Ok(result);
            var response = new { message = "Not Data found" };
            return NotFound();
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,Employee employee)
        {            
            var result = await _employeeService.Update(id, employee);
            if (result != null) return Ok(result);
            return BadRequest();

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _employeeService.Delete(id);
            if (result != null) return Ok(result);
            var response = new { message = "Not Found" };
            return NotFound(response);
        }
    }
}
