using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data.SeedData
{
    public class DataTypeEditors
    {
        public static List<BookEntity> Books_File_DataTypesEditor(List<BooksJsonDataType> Books_JSONs)
        {
            List<BookEntity> Books = new List<BookEntity>();
            foreach (var item in Books_JSONs)
            {
                if (!(string.IsNullOrEmpty(item.ISBN10) || string.IsNullOrEmpty(item.ISBN13) ||
                    string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.SubTitle) ||
                    string.IsNullOrEmpty(item.Thumbnail) || string.IsNullOrEmpty(item.Authors)||
                    string.IsNullOrEmpty(item.Categories) || string.IsNullOrEmpty(item.Description)||
                    string.IsNullOrEmpty(item.AverageRating) ||string.IsNullOrEmpty(item.PagesNo)||
                    string.IsNullOrEmpty(item.RatingsCount) || string.IsNullOrEmpty(item.PublishedYear)))
                {
                    Random rnd = new Random();
                    BookEntity book = new BookEntity()
                    {
                        ISBN13 = long.Parse(item.ISBN13),
                        ISBN10 = item.ISBN10,
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Authors = item.Authors,
                        Categories = item.Categories,
                        Thumbnail = item.Thumbnail,
                        Description = item.Description,
                        PagesNo = int.Parse(item.PagesNo),
                        AverageRating = double.Parse(item.AverageRating),
                        PublishedYear = int.Parse(item.PublishedYear),
                        RatingsCount = long.Parse(item.RatingsCount),
                        Price = rnd.Next(120, 500),
                        AvailableNo = rnd.Next(56)
                    };
                    Books.Add(book);
                }
            }
            return Books;
        }

    }
}
