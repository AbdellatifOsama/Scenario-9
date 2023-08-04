using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data.SeedData
{
    public class BooksJsonDataType
    {
        public string ISBN13 { get; set; }
        public string ISBN10 { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Authors { get; set; }
        public string Categories { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string PublishedYear { get; set; }
        public string AverageRating { get; set; }
        public string PagesNo { get; set; }
        public string RatingsCount { get; set; }
    }
}
