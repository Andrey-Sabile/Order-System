using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.MenuItems.Commands;

public record DeleteMenuItemCommand(int Id): IRequest;

public class DeleteMenuItemCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteMenuItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.MenuItems.FindAsync([ request.Id ], cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        _context.MenuItems.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}