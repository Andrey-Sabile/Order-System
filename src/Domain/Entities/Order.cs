namespace OrderSystem.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public IList<MenuItem> Items { get; } = [];

    public int? tableNumber { get; set; }
}