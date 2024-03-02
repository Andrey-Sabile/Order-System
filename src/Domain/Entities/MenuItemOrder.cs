namespace OrderSystem.Domain.Entities;

public class MenuItemOrder : BaseAuditableEntity
{
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int OrderQuantity { get; set; } = 1;
    public required Order Order { get; set; }
    public required MenuItem MenuItem { get; set; }
}
