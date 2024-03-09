using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.MenuItems.Commands;

public record UpdateMenuItemCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Price { get; init; }
}

public class UpdateMenuItemCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateMenuItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.MenuItems.FindAsync([request.Id], cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);
    }
}