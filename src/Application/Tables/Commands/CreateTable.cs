using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Tables.Commands;

public record CreateTableCommand : IRequest<int>
{
    public int TableNumber { get; init; }

    public int Capacity { get; init; }
}

public class CreateTableCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTableCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        var entity = new Table
        {
            TableNumber = request.TableNumber,
            Capacity = request.Capacity,
        };

        _context.Tables.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}