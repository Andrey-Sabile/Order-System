using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.MenuItems.Queries;

public record GetMenuItemsQuery : IRequest<IList<MenuItem>>;

public class GetMenuItemsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetMenuItemsQuery, IList<MenuItem>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IList<MenuItem>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.MenuItems
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}