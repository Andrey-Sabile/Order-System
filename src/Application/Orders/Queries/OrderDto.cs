using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries;

public class OrderDto
{
    public int? Id { get; init; }

    public int? TableNumber { get; init; }

    public bool? Done { get; init; } = false;

    public bool Paid { get; init; } = false;

    public IReadOnlyCollection<MenuItemOrderDto> MenuItemOrders { get; init; } = [];

    public decimal TotalOrderPrice => MenuItemOrders.Sum(item => item.TotalPrice);

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
