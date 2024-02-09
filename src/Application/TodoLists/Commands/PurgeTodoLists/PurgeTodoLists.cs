using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Application.Common.Security;
using OrderSystem.Domain.Constants;

namespace OrderSystem.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler(IApplicationDbContext context) : IRequestHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
