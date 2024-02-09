using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Application.MenuItems.Commands;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Commands;

public record CreateOrderCommand : IRequest<int>
{
    public required IEnumerable<int> MenuItemIds { get; init; }
}

public class CreateOrderCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new Order{};

        foreach (var menuItemId in request.MenuItemIds)
        {
            var menuItemEntity = await _context.MenuItems.FindAsync([ menuItemId ], cancellationToken);
            Guard.Against.NotFound(menuItemId, menuItemEntity);

            entity.Items.Add(menuItemEntity);
        }

        _context.Orders.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}