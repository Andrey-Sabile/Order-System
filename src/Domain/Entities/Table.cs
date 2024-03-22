namespace OrderSystem.Domain.Entities;

public class Table : BaseAuditableEntity
{
    public int TableNumber { get; set; }

    public int Capacity { get; set; }
}