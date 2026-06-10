using AutoMapper;

namespace Storage.API.Profiles;

internal class ProductProfile : Profile
{
  public ProductProfile()
  {
    CreateMap<Models.Product, Models.ProductDto>();
    CreateMap<Models.ProductForUpdateDto, Models.Product>();
    CreateMap<Models.ProductForCreationDto, Models.Product>();
  }
}
