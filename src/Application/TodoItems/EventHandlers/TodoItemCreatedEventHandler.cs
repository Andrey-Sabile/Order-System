﻿using Microsoft.Extensions.Logging;
using OrderSystem.Domain.Events;

namespace OrderSystem.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger = logger;

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("OrderSystem Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
