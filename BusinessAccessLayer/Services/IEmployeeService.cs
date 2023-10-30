﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IEmployeeService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(int id);
        Task<T?> Add(T entity);
        Task<T?> Update(int id, T entity);
        Task<T?> Delete(int id);
    }
}
