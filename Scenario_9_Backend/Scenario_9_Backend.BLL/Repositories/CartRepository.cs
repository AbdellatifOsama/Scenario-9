using Microsoft.EntityFrameworkCore;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Repositories
{
    public class CartRepository : GenericRepository<CartEntity>, ICartRepository
    {
        public CartRepository(LibraryContext context) : base(context)
        {
            Context = context;
        }

        public LibraryContext Context { get; }

        public async Task<List<CartEntity>> GetAllCartsForUser(string userId)
        {
            var items = await Context.Set<CartEntity>().Include(x=>x.BookEntity).Where(x=>x.ApplicationUserId == userId).ToListAsync();
            return items;
        }

        public async Task<CartEntity> GetCartByDetails(string userId, int BookEntityId)
        {
            var item = await Context.Set<CartEntity>().Where(x => (x.ApplicationUserId == userId && x.BookEntityId == BookEntityId)).FirstOrDefaultAsync();
            return item;
        }

        public async Task<bool> IsSimillerCartFound(string UserId,int BookId)
        {
            var items = await Context.Set<CartEntity>().Where(x => (x.ApplicationUserId == UserId && x.BookEntityId == BookId)).ToListAsync();
            return (items.Count!=0);
        }
    }
}
