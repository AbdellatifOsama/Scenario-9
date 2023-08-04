using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Interfaces
{
    public interface ICartRepository:IGenericRepository<CartEntity>
    {
        public Task<List<CartEntity>> GetAllCartsForUser(string userId);
        public Task<bool> IsSimillerCartFound(string UserId, int BookId);
        public Task<CartEntity> GetCartByDetails(string userId, int BookEntityId);
    }
}
