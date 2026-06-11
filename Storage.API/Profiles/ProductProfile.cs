using AutoMapper;
using Storage.API.Entities;

namespace Storage.API.Profiles;

internal class ProductProfile : Profile
{
  public ProductProfile()
  {
    CreateMap<Product, Models.ProductDto>();
    CreateMap<Models.ProductDto, Product>();
    CreateMap<Models.ProductForUpdateDto, Product>();
    CreateMap<Models.ProductForCreationDto, Product>();
  }
}
