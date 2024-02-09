using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries;

public class OrderDto
{
    public int? Id { get; init; }

    public int? TableNumber { get; init; }
    
    public bool? Done { get; init; } = false;

    public IReadOnlyCollection<MenuItemDto> Items { get; init; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
