using AutoMapper;
using BBL.DTO;
using BLL.DTO;
using DAL.Entities;

namespace BBL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<GetSkippedDaysDTO, SkippedDays>().ReverseMap();

            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<CreateProductDTO, Product>().ReverseMap();

            CreateMap<SkippedDaysDTO, SkippedDays>().ReverseMap();

            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<ReportDTO, Report>().ReverseMap();
        }
    }
}
