namespace OrderSystem.Domain.Entities
{
    public class MenuItemOrder : BaseAuditableEntity
    {
        public int OrdersId { get; set; }
        public int ItemsId { get; set; }
        public int OrderQuantity { get; set; } = 1;
    }
}