using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters
{
    public interface ISpec
    {
        public Expression<Func<BookEntity, bool>> ISBN13 { get; set; }
        public Expression<Func<BookEntity, bool>> MinPrice { get; set; }
        public Expression<Func<BookEntity, bool>> MaxPrice { get; set; }
        public Expression<Func<BookEntity, bool>> Author { get; set; }
        public Expression<Func<BookEntity, bool>> Category { get; set; }
        public Expression<Func<BookEntity, bool>> Title { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; }

    }
}
