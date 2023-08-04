using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters
{
    public class BookFiltersParams
    {
        public int? ISBN13 { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
    }
}
