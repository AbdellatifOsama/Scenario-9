using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            //Id
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Id)
                .HasColumnType("int")
                .UseIdentityColumn(1);
            //ISNB13
            builder.Property(book => book.ISBN13)
                .IsRequired()
                .HasColumnType("bigint");
            //ISBN10
            builder.Property(book => book.ISBN10)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");
            //Title
            builder.Property(book => book.Title)
                .IsRequired()
                .HasColumnType("nvarchar(max)"); 
            //Sub Title
            builder.Property(book => book.SubTitle)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            //Authors
            builder.Property(book => book.Authors)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            //Categories
            builder.Property(book => book.Categories)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            //Thumbnail
            builder.Property(book => book.Thumbnail)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            //Description
            builder.Property(book => book.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
            //Published_Year
            builder.Property(book => book.PublishedYear)
                .IsRequired()
                .HasColumnType("int");
            //Rate
            builder.Property(book => book.AverageRating)
                .IsRequired()
                .HasColumnType("decimal(3,2)");
            //num Pages
            builder.Property(book => book.PagesNo)
                .IsRequired()
                .HasColumnType("int");
            //Ratings_Count
            builder.Property(book => book.RatingsCount)
                .IsRequired()
                .HasColumnType("bigint");
            //AvailableNo
            builder.Property(book => book.AvailableNo)
                .IsRequired()
                .HasColumnType("int");
            //price
            builder.Property(book => book.Price)
                .IsRequired()
                .HasColumnType("money");
        }
    }
}
