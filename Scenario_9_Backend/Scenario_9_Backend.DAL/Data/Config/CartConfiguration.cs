using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data.Config
{
    internal class CartConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.HasKey(p => new { p.BookEntityId, p.ApplicationUserId });
            builder.HasOne(p => p.ApplicationUser).WithMany();
            builder.HasOne(p => p.BookEntity).WithMany();
        }
    }
}
