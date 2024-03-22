using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<MenuItem> MenuItems { get; }

    DbSet<Order> Orders { get; }

    DbSet<MenuItemOrder> MenuItemOrders { get; }

    DbSet<Table> Tables { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
