using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        private readonly LibraryContext context;

        public BookRepository(LibraryContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<string>> GetCategories()
        {
            var Categories =  await context.Set<BookEntity>().GroupBy(B => B.Categories).ToListAsync();
            var CategoriesKeys = new List<string>();
            foreach (var category in Categories)
            {
                CategoriesKeys.Add(category.Key.ToLower());
            }
            return CategoriesKeys.Distinct();
        }
        public async Task<IEnumerable<BookEntity>> GetBooksWithFilters(ISpec bookFiltersSpecification)
        {
            var items = await BookFiltersSpecificationEvaluator.GetQuery(context.Set<BookEntity>(),bookFiltersSpecification).ToListAsync();

            return items;
        }
    }
}
