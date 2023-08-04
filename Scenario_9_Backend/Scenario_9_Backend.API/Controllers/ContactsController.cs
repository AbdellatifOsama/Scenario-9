using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Entities;

namespace Scenario_9_Backend.API.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public ContactsController(IContactRepository contactRepository,IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Contacts(ContactDto ContactDto)
        {
            var mappedContact = mapper.Map<ContactsEntity>(ContactDto);
            if (ModelState.IsValid)
            {
                contactRepository.Add(mappedContact);
                return Ok(new
                {
                    message = "success"
                });
            }
            return BadRequest();
        }
    }
}
