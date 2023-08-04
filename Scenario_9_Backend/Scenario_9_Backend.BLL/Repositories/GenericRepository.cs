using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Specifications;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext context;

        public GenericRepository(LibraryContext context)
        {
            this.context = context;
        }
        public async Task<T?> Get(int id)
        {
            var item = await context.Set<T>().FindAsync(id);
            return item;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public async Task<List<T>> GetAllWithSpecAsync(IBaseSpecification<T> spec)
        {
            var items = await ApplySpecifications(spec).ToListAsync();
            return items;
        }

        private IQueryable<T> ApplySpecifications(IBaseSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }

        public async Task<List<T>> GetAll()
        {
            var items  = await context.Set<T>().ToListAsync();
            return items;
        }
        public void Update(T Entity)
        {
            context.Set<T>().Update(Entity);
            context.SaveChanges();
        }
    }
}
