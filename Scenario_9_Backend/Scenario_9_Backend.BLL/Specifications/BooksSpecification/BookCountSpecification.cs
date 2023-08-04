using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Specifications.BooksSpecification
{
    public class BookCountSpecification:BaseSpecification<BookEntity>
    {
        public BookCountSpecification(BooksParams BooksParams)
        {
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
                Criteria = P => P.Title.Contains(BooksParams.Search);
            }
        }
    }
}
