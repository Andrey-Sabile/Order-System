using OrderSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderSystem.Infrastructure.Data.Configurations;

public class MenuItemOrderConfiguration : IEntityTypeConfiguration<MenuItemOrder>
{
    public void Configure(EntityTypeBuilder<MenuItemOrder> builder)
    {
        builder.HasKey(e => new { e.OrderId, e.MenuItemId });
    }
}
