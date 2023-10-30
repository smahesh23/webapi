using DataAccessLayer.DatabaseModels;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeService(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee?> Add(Employee entity)
        {
            return await _employeeRepository.Add(entity);
        }

        public async Task<Employee?> Delete(int id)
        {
            return await (_employeeRepository.Delete(id));
        }

        public async Task<Employee?> Get(int id)
        {
            return await (_employeeRepository.Get(id));
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee?> Update(int id, Employee entity)
        {
            return await _employeeRepository.Update(id, entity);
        }
    }
}
