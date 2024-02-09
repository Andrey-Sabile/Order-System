using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Orders.Queries
{
    public class MenuItemDto
    {
        public string? Name { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<MenuItem, MenuItemDto>();
            }
        }
    }
}