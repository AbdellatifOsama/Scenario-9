using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Entities
{
    public class BookEntity:BaseEntity
    {
        public Int64 ISBN13 { get; set; }
        public string ISBN10 { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Authors { get; set; }
        public string Categories { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public double AverageRating { get; set; }
        public int PagesNo { get; set; }
        public long RatingsCount { get; set; }
        public int AvailableNo { get; set; }
        public double Price { get; set; }
    }
}
