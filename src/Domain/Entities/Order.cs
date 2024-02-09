namespace OrderSystem.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public IList<MenuItem> Items { get; } = [];

    public int? TableNumber { get; set; }
    
    public bool? Done { get; set; } = false;
}