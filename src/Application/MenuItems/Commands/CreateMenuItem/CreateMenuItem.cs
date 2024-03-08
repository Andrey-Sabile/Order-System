using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;
using OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

namespace OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

public record CreateMenuItemCommand : IRequest<int>
{
    public required NewMenuItemDto NewMenuItem { get; init; }
}

public class CreateMenuItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateMenuItemCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new MenuItem
        {
            Name = request.NewMenuItem.Name,
            Price = request.NewMenuItem.Price,
        };

        _context.MenuItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}