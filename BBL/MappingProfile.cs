using AutoMapper;
using BBL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BBL
{
    public class MappingProfile : Profile //TODO: hier or in folder?
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<RoleDTO, Role>().ReverseMap();

            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<BrandDTO, Brand>().ReverseMap();

            CreateMap<ReportDTO, Report>().ReverseMap();

            CreateMap<List<ProductDTO>, List<Product>>().ReverseMap();

            CreateMap<List<ReportDTO>, List<Report>>().ReverseMap();
        }
    }
}
