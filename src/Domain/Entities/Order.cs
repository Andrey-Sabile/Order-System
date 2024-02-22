namespace OrderSystem.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public int? TableNumber { get; set; }

    public IList<MenuItem> Items { get; set; } = [];

    public IList<MenuItemOrder> MenuItemOrders { get; set; } = [];

    public bool? Done { get; set; } = false;
}