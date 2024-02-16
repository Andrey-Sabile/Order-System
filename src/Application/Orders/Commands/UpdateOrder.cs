using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.Orders.Commands;

public record UpdateOrderCommand : IRequest
{
    public int OrderId { get; init; }
}

public class UpdateOrderCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = await _context.Orders.FindAsync([ request.OrderId ], cancellationToken);
        Guard.Against.NotFound( request.OrderId, orderEntity);

        orderEntity.Done = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}