using Scenario_9_Backend.BLL.Specifications;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T?> Get(int id);
        public Task<List<T>> GetAllWithSpecAsync(IBaseSpecification<T> spec);
        public void Add(T entity);
        public Task<List<T>> GetAll();
        public void Delete(T entity);
        public void Update(T entity);
    }
}
