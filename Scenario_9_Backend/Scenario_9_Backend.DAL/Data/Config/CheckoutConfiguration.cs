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
    public class CheckoutConfiguration : IEntityTypeConfiguration<CheckoutEntity>
    {
        public void Configure(EntityTypeBuilder<CheckoutEntity> builder)
        {
            builder.HasOne(p => p.ApplicationUser).WithMany();

        }
    }
}
