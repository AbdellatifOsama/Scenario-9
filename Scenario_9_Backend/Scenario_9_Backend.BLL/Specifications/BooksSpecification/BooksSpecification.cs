using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification
{
    public class BooksSpecification : BaseSpecification<BookEntity>
    {
        /// This Constructor Use When Need to Get All Books
        public BooksSpecification(BooksParams BooksParams)
        {
            //AddOrderBy(P => P.Title);
            ApplyPaging(BooksParams.PageSize * (BooksParams.PageIndex - 1), BooksParams.PageSize);

            if (!string.IsNullOrEmpty(BooksParams.Sort))
            {
                switch (BooksParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(P => P.Price);
                        break;
                    case "titleAsc":
                        AddOrderBy(P => P.Title);
                        break;
                    case "titleDesc":
                        AddOrderByDescending(P => P.Title);
                        break;
                    default:
                        break;
                }
            }
            
            if (!string.IsNullOrEmpty(BooksParams.Search))
            {
                Criteria = P=> P.Title.Contains(BooksParams.Search);
            }
        }
    }
}
