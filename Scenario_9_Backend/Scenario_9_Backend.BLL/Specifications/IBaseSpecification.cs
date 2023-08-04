using Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications
{
    public interface IBaseSpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        //public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; }
    }
}
