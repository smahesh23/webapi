using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IEmployeeRepository<T> where T : class,IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(int id);
        Task<T?> Add(T entity);
        Task<T?> Update(int id,T entity);
        Task<T?> Delete(int id);
        
    }
}
