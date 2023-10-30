using DataAccessLayer.DatabaseContexts;
using DataAccessLayer.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
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
            var result = _employeeDbContext.Set<Employee>().Add(emp);
            await _employeeDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Employee?> Get(int id)
        {
            var employee = await _employeeDbContext.Set<Employee>().FindAsync(id);
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeDbContext.Set<Employee>().ToListAsync();
        }
        public async Task<Employee?> Update(int id, Employee addEmployee)
        {
            var emp = _employeeDbContext.Set<Employee>().Find(id);
            if (emp != null)
            {
                emp.Name = addEmployee.Name;
                emp.Company = addEmployee.Company;
                emp.Phone = addEmployee.Phone;
                emp.City = addEmployee.City;
                emp.Role = addEmployee.Role;
                 await _employeeDbContext.SaveChangesAsync();
                return emp;

            }
            return null;
            //Console. WriteLine(emp.Name);           
        }

        public async Task<Employee?> Delete(int id)
        {
            var emp = _employeeDbContext.Set<Employee>().Find(id);
            if (emp != null)
            {
                _employeeDbContext.Employees.Remove(emp);
                await _employeeDbContext.SaveChangesAsync();
                return emp;
            }
            return null;
        }
    }

}
