using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Tables.Queries;

public record GetTablesQuery : IRequest<IList<TableDto>>;

public class GetTablesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTablesQuery, IList<TableDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<TableDto>> Handle(GetTablesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tables
            .AsNoTracking()
            .ProjectTo<TableDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}