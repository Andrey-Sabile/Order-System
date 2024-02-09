﻿using OrderSystem.Application.Common.Interfaces;
using OrderSystem.Domain.Events;

namespace OrderSystem.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
