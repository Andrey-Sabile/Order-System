using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;
using OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

namespace OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

public record CreateMenuItemCommand : IRequest<int>
{
    public string? Name { get; init; }
    public decimal Price { get; init; }
}

public class CreateMenuItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateMenuItemCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new MenuItem
        {
            Name = request.Name,
            Price = request.Price,
        };

        _context.MenuItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}