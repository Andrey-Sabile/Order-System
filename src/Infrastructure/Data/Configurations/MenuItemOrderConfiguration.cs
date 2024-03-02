using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Infrastructure.Data.Configurations;

public class MenuItemOrderConfiguration : IEntityTypeConfiguration<MenuItemOrder>
{
    public void Configure(EntityTypeBuilder<MenuItemOrder> builder)
    {
        builder.HasKey(mio => new { mio.OrderId, mio.MenuItemId });
        
        builder.HasOne(mio => mio.Order)
            .WithMany(o => o.MenuItemOrders)
            .HasForeignKey(mio => mio.OrderId);
        
        builder.HasOne(mio => mio.MenuItem)
            .WithMany(mi => mi.MenuItemOrders)
            .HasForeignKey(mio => mio.MenuItemId);
    }
}
