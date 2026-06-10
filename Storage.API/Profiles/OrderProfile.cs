using AutoMapper;
using Storage.API.Entities;

namespace Storage.API.Profiles;

public class OrderProfile : Profile
{
  public OrderProfile()
  {
    CreateMap<Models.OrderDto, Order>();
  }
}
