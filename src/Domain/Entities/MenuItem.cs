using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Domain.Entities;

public class MenuItem : BaseAuditableEntity
{
    public string? Name { get; set; }

    [Range(0, int.MaxValue)]
    public int Price { get; set; }

    public IList<Order> Orders { get; set; } = [];

    public IList<MenuItemOrder> MenuItemOrders { get; set; } = [];
}