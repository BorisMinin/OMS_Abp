using AutoMapper;
using OMS_Abp.Domain.Entities;
using OMS_Abp.DTOs.Product;

namespace OMS_Abp;

public class OMS_AbpApplicationAutoMapperProfile : Profile
{
    public OMS_AbpApplicationAutoMapperProfile()
    {
        CreateMap<Product, GetProductDto>().ReverseMap();
    }
}