using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Repositories
{
    public class CheckoutRepository : GenericRepository<CheckoutEntity>, ICheckoutRepository
    {
        private readonly LibraryContext context;

        public CheckoutRepository(LibraryContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<CheckoutEntity>> GetAllCheckoutsForUser(string email)
        {
            var items = await context.Set<CheckoutEntity>().Where(c => c.ApplicationUserEmail == email).ToListAsync();
            return items;
        }
    }
}
