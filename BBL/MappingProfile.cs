using AutoMapper;
using BBL.DTO;
using DAL.Entities;

namespace BBL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();
        }
    }
}
