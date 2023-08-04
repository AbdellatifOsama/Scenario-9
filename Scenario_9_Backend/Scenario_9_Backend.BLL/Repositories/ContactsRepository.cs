using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Data;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.BLL.Repositories
{
    public class ContactsRepository : GenericRepository<ContactsEntity>, IContactRepository
    {
        public ContactsRepository(LibraryContext context) : base(context)
        {
        }
    }
}
