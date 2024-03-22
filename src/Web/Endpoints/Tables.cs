using OrderSystem.Domain.Entities;
using OrderSystem.Application.Tables.Commands;
using OrderSystem.Application.Tables.Queries;

namespace OrderSystem.Web.Endpoints;

public class Tables : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTables)
            .MapPost(CreateTable);
    }

    public async Task<IList<TableDto>> GetTables(ISender sender)
    {
        return await sender.Send(new GetTablesQuery());
    }

    public async Task<int> CreateTable(ISender sender, CreateTableCommand command)
    {
        return await sender.Send(command);
    }
}