using AutoMapper;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.DAL.Entities;
using Scenario_9_Backend.DAL.Entities.Checkout;

namespace Scenario_9_Backend.API.Helpers
{

    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            RegisterAccountMapping();
            ContactsRegisterAccountMapping();
            CartMapping();
            CheckoutMapping();
            CartsForUseMapping();
        }
        public void RegisterAccountMapping()
        {
            CreateMap<RegisterDto, ApplicationUser>()
             .ForMember(P => P.UserName, C => C.MapFrom(D => D.FirstName + D.LastName));
        }
        public void ContactsRegisterAccountMapping()
        {
            CreateMap<ContactDto, ContactsEntity>()
            .ReverseMap();
        }
        public void CartMapping()
        {
            CreateMap<CartDto, CartEntity>()
            .ReverseMap();
        }
        public void CheckoutMapping()
        {
            CreateMap<CheckoutDto, CheckoutEntity>()
            .ReverseMap();
        }
        public void CartsForUseMapping()
        {
            CreateMap<CartsForUserDto, CartEntity>()
            .ReverseMap();
        }
    }
}
