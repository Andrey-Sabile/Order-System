using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Application.Common.Security;
using OrderSystem.Application.TodoLists.Queries.GetTodos;

namespace OrderSystem.Application.TodoLists.Queries.GetTodosRaw;

[Authorize]
public record GetTodosRawQuery : IRequest<IList<TodoListDto>>;

public class GetTodosRawQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodosRawQuery, IList<TodoListDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<TodoListDto>> Handle(GetTodosRawQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .AsNoTracking()
            .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Title)
            .ToListAsync(cancellationToken);
    }
}