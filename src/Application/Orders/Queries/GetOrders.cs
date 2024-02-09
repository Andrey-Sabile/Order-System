using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries;

public record GetOrdersQuery : IRequest<IList<OrderDto>>;

public class GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetOrdersQuery, IList<OrderDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Orders
            .AsNoTracking()
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return entity;
    }
}