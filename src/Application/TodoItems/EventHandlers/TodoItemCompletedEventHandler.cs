﻿using Microsoft.Extensions.Logging;
using OrderSystem.Domain.Events;

namespace OrderSystem.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger = logger;

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("OrderSystem Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
