using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.Tables.Queries;

public class TableDto
{
    public int TableNumber { get; init; }

    public int Capacity { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Table, TableDto>();
        }
    }
}