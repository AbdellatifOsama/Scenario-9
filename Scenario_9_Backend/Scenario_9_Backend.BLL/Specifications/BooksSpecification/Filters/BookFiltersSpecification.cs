using Microsoft.IdentityModel.Tokens;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters
{
    public class BookFiltersSpecification : ISpec
    {
        private readonly BookFiltersParams bookFiltersParams;
        public Expression<Func<BookEntity, bool>> ISBN13 { get; set; }
        public Expression<Func<BookEntity, bool>> MinPrice { get; set; }
        public Expression<Func<BookEntity, bool>> MaxPrice { get; set; }
        public Expression<Func<BookEntity, bool>> Author { get; set; }
        public Expression<Func<BookEntity, bool>> Category { get; set; }
        public Expression<Func<BookEntity, bool>> Title { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; }


        public BookFiltersSpecification(BookFiltersParams bookFiltersParams)
        {
            this.bookFiltersParams = bookFiltersParams;
            AddFilters();
        }
        public void AddFilters()
        {
            if (bookFiltersParams.ISBN13 is not null)
            {
                ISBN13 = B => B.ISBN13 == bookFiltersParams.ISBN13;
            }
            if (!string.IsNullOrEmpty(bookFiltersParams.Title))
            {
                Title = B => B.Title.ToLower().Contains(bookFiltersParams.Title);
            }
            if (!string.IsNullOrEmpty(bookFiltersParams.Author))
            {
                Author = B => B.Authors.ToLower().Contains(bookFiltersParams.Author ?? "");
            }
            if (!string.IsNullOrEmpty(bookFiltersParams.Category))
            {
                Category = B => B.Categories.ToLower().Contains(bookFiltersParams.Category ?? "");
            }
            MinPrice = B => B.Price >= bookFiltersParams.MinPrice;
            MaxPrice = B => B.Price <= bookFiltersParams.MaxPrice;
            ApplyPaging(bookFiltersParams.PageSize * (bookFiltersParams.PageIndex - 1), bookFiltersParams.PageSize);
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
