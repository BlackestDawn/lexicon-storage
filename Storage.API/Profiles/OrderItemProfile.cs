using AutoMapper;
using Storage.API.Entities;

namespace Storage.API.Profiles;

public class OrderItemProfile : Profile
{
  public OrderItemProfile()
  {
    CreateMap<Models.OrderItemDto, OrderItem>();
    CreateMap<OrderItem, Models.OrderItemDto>();
    CreateMap<Models.OrderItemForCreationDto, OrderItem>()
      .ForMember(dest => dest.Product, opt => opt.Ignore());
  }
}
