using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Models;

namespace ProductManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // VM -> DTO
            CreateMap<ProductCreateVm, CreateProductDto>();
            CreateMap<ProductFilterVm, ProductFilterDto>();

            CreateMap<ServiceProviderCreateVm, CreateServiceProviderDto>();

            // DTO -> VM 
            CreateMap<ProductDto, ProductVm>();
            CreateMap<ServiceProviderDto, ServiceProviderVm>();

            // ProductDto -> ProductVm
            CreateMap<ProductDto, ProductVm>()
            .ForMember(dest => dest.ServiceProviderName, opt => opt.MapFrom(src => src.ServiceProviderName ?? ""));

            CreateMap<CreateServiceProviderDto, ServiceProviders>();
            CreateMap<ServiceProviderDto, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));


            CreateMap<ServiceProviders, ServiceProviderDto>();
            CreateMap<Product, ProductDto>();

            // تأكدي أن عندك هذا:
            CreateMap<ProductDto, ProductVm>()
                .ForMember(d => d.ServiceProviderName,
                           o => o.MapFrom(s => s.ServiceProviderName ?? string.Empty));

            // خيـار A: النوع الدقيق
            CreateMap<(IReadOnlyList<ProductDto> Products, ProductFilterVm Filter), ProductsIndexVm>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Products))
                .ForMember(d => d.Filter, o => o.MapFrom(s => s.Filter));

            // أو خيـار B: عام
            CreateMap<(IEnumerable<ProductDto> Products, ProductFilterVm Filter), ProductsIndexVm>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Products))
                .ForMember(d => d.Filter, o => o.MapFrom(s => s.Filter));



        }
    }
}
