using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.DAL.Entities;
using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data
{
    public class LibraryContext:IdentityDbContext<ApplicationUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {
            
        }
        DbSet<BookEntity> Books { get; set; }
        DbSet<ContactsEntity> Contacts { get; set; }
        DbSet<CartEntity> Carts { get; set; }
        DbSet<CheckoutEntity> Checkouts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
