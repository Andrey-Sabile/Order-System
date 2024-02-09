using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries;

public record GetOrdersQuery : IRequest<IList<Order>>;

public class GetOrdersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetOrdersQuery, IList<Order>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<IList<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Orders
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}