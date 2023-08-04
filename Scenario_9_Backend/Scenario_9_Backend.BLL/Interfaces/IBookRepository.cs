using Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Interfaces
{
    public interface IBookRepository:IGenericRepository<BookEntity>
    {
        public Task<IEnumerable<string>> GetCategories();
        public Task<IEnumerable<BookEntity>> GetBooksWithFilters(ISpec bookFiltersSpecification);
    }
}
