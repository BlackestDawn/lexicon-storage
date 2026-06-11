using AutoMapper;
using Storage.API.Entities;

namespace Storage.API.Profiles;

public class CustomerProfile : Profile
{
  public CustomerProfile()
  {
    CreateMap<Models.CustomerDto, Customer>();
    CreateMap<Customer, Models.CustomerDto>();
    CreateMap<Models.CustomerForCreationDto, Customer>();
  }
}
