using Scenario_9_Backend.DAL.Entities.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Interfaces
{
    public interface ICheckoutRepository:IGenericRepository<CheckoutEntity>
    {
        public Task<List<CheckoutEntity>> GetAllCheckoutsForUser(string email);
    }
}
