using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.Orders.Commands;

public record DeleteOrderCommand(int Id): IRequest;

public class DeleteOrderCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteOrderCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Orders.FindAsync([ request.Id ], cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        _context.Orders.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}