using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Repositories;
using Scenario_9_Backend.DAL.Entities;
using Scenario_9_Backend.DAL.Entities.Checkout;

namespace Scenario_9_Backend.API.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ICartRepository cartRepository;
        private readonly ICheckoutRepository checkoutRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public CheckoutController(ICartRepository cartRepository, ICheckoutRepository checkoutRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCheckout(CheckoutDto checkoutDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(checkoutDto.ApplicationUserEmail);
                var Checkout = mapper.Map<CheckoutEntity>(checkoutDto);
                Checkout.ApplicationUserId = user.Id;
                checkoutRepository.Add(Checkout);
                var UserCarts = await cartRepository.GetAllCartsForUser(user.Id);
                foreach (var item in UserCarts)
                {
                    cartRepository.Delete(item);
                }
                return Ok(new
                {
                    message = "success"
                });
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllForUser(string email)
        {
            var items = await checkoutRepository.GetAllCheckoutsForUser(email);
            return Ok(items);
        }
    }
}
