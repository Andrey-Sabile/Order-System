using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.Orders.Commands;

public record UpdateOrderQuantityCommand : IRequest
{
    public int OrderId { get; init; }

    public int MenuItemId { get; init; }

    public int Quantity { get; init; }
}

public class UpdateOrderQuantityCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateOrderQuantityCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateOrderQuantityCommand request, CancellationToken cancellationToken)
    {
        var menuItemOrderEntity = await _context.MenuItemOrders.FindAsync([request.OrderId, request.MenuItemId], cancellationToken);
        Guard.Against.NotFound(request.OrderId, menuItemOrderEntity);
        Guard.Against.NotFound(request.MenuItemId, menuItemOrderEntity);

        menuItemOrderEntity.OrderQuantity = request.Quantity;

        await _context.SaveChangesAsync(cancellationToken);
    }
}