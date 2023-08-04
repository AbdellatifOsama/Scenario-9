using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.DAL.Entities;
using Scenario_9_Backend.DAL.Entities.Checkout;

namespace Scenario_9_Backend.API.Controllers
{
    public class CartsController : BaseController
    {
        private readonly ICartRepository cartRepository;
        private readonly ICheckoutRepository checkoutRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public CartsController(ICartRepository cartRepository,ICheckoutRepository checkoutRepository,IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            this.cartRepository = cartRepository;
            this.checkoutRepository = checkoutRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCart(CartDto cartDto)
        {
            if (ModelState.IsValid) 
            {
                var user = await userManager.FindByEmailAsync(cartDto.ApplicationUserEmail);
                var Cart = mapper.Map<CartEntity>(cartDto);
                if (!(await cartRepository.IsSimillerCartFound(user.Id, cartDto.BookEntityId)))
                {
                    Cart.ApplicationUserId = user.Id;
                    cartRepository.Add(Cart);
                }
                else
                {
                    var CurrentCart = await cartRepository.GetCartByDetails(user.Id, cartDto.BookEntityId);
                    CurrentCart.Quantity = CurrentCart.Quantity + 1;
                    cartRepository.Update(CurrentCart);
                }
                return Ok(new
                {
                    message = "success"
                });
            }
            return BadRequest();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllCartsForUser(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var items = await cartRepository.GetAllCartsForUser(user.Id);
                var mapped = mapper.Map<List<CartsForUserDto>>(items);
                return Ok(mapped);
            }
            return NotFound();
        }
        [HttpDelete("Delete")]
        public async Task DeleteCart(string email, int  bookId)
        {
            var user = await userManager.FindByEmailAsync(email);
            var item = await cartRepository.GetCartByDetails(user.Id, bookId);
            cartRepository.Delete(item);
        }
        
    }
}
