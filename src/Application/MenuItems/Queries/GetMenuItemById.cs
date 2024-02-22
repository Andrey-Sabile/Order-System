using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.MenuItems.Queries;

public record GetMenuItemByIdQuery : IRequest<MenuItem>
{
    public int Id { get; init; }
}

public class GetMenuItemByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetMenuItemByIdQuery, MenuItem>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<MenuItem> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.MenuItems.FindAsync([request.Id], cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        return entity;
    }
}