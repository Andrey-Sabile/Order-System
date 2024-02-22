using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Application.Orders.Commands.CreateOrder;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Commands;

public record CreateOrderCommand : IRequest<int>
{
    public required IEnumerable<NewOrderDto> Items { get; init; }
}

public class CreateOrderCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order { };

        foreach (var item in request.Items)
        {
            var menuItemEntity = await _context.MenuItems.FindAsync([item.MenuItemId], cancellationToken);
            Guard.Against.NotFound(item.MenuItemId, menuItemEntity);
            order.Items.Add(menuItemEntity);

            var menuItemOrder = new MenuItemOrder
            {
                OrderId = order.Id,
                MenuItemId = menuItemEntity.Id,
                OrderQuantity = item.ItemQuantity
            };
            order.MenuItemOrders.Add(menuItemOrder);
        }

        _context.Orders.Add(order);

        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}