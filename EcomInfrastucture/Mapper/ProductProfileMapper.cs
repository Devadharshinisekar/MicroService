using AutoMapper;
using EcomDomain.Aggregate;
using EcomDomain.Enities;
using EcomInfrastucture.DataModels;
namespace EcomInfrastucture.Mapper;

public class ProductProfileMapper: Profile
{
    public ProductProfileMapper(){
        CreateMap<Product, ProductDataModel>()
        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductEntity!.ProductId))
        .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductEntity!.ProductName))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductEntity!.Description))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductEntity!.Price))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ProductEntity!.Quantity))
        .ReverseMap();
    }
}
