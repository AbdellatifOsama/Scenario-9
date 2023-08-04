using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters
{
    public class BookFiltersSpecificationEvaluator
    {
            public static IQueryable<BookEntity> GetQuery(IQueryable<BookEntity> inputQuery, ISpec spec)
            {
                var query = inputQuery;
                if (spec.ISBN13 != null)
                    query = query.Where(spec.ISBN13);
                if (spec.Title is not null)
                    query = query.Where(spec.Title);
                if (spec.Author is not null)
                    query = query.Where(spec.Author);
                if (spec.Category is not null)
                    query = query.Where(spec.Category);
                query = query.Where(spec.MinPrice);
                query = query.Where(spec.MaxPrice);
                if (spec.IsPagingEnabled)
                    query = query.Skip(spec.Skip).Take(spec.Take);
            return query;
            }
    }
}
