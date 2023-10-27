using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository<Employee> 
    {
        private readonly EmployeeContext employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<Employee?> Add(Employee employee)
        {
            var emp = new Employee()
            {
                Name = employee.Name,
                Company = employee.Company,
                Phone = employee.Phone,
                City = employee.City,
                Role = employee.Role,
            };
            var result = employeeContext.Set<Employee>().Add(emp);
            await employeeContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Employee?> Get(int id)
        {
            var employee = await employeeContext.Set<Employee>().FindAsync(id);
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeContext.Employees.ToListAsync();
        }
        public async Task<Employee?> Update(int id,Employee addEmployee)
        {
            var emp = employeeContext.Employees.Find(id);
            if(emp != null)
            {
                emp.Name = addEmployee.Name;
                emp.Company = addEmployee.Company;
                emp.Phone = addEmployee.Phone;
                emp.City = addEmployee.City;
                emp.Role = addEmployee.Role;
                await employeeContext.SaveChangesAsync();
                return emp;

            }
            return null;
            //Console. WriteLine(emp.Name);           
        }

        public async Task<Employee?> Delete(int id)
        {
            var emp=employeeContext.Employees.Find(id);
            if(emp != null)
            {
                employeeContext.Employees.Remove(emp);
                await employeeContext.SaveChangesAsync();
                return emp;
            }
            return null;
        }
        
    }
}
