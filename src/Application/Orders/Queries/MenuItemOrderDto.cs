using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries
{
    public class MenuItemOrderDto
    {
        public int OrderQuantity { get; set; }
        
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<MenuItemOrder, MenuItemOrderDto>();
            }
        }
    }
}