using OrderSystem.Application.Orders.Commands;
using OrderSystem.Application.Orders.Queries;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Web.Endpoints;

public class Orders : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetOrders)
            .MapPost(CreateOrder)
            .MapPut(UpdateOrder, "{id}")
            .MapDelete(DeleteOrder, "{id}");
    }

    public async Task<IList<Order>> GetOrders(ISender sender)
    {
        return await sender.Send(new GetOrdersQuery());
    }
    
    public async Task<int> CreateOrder(ISender sender, CreateOrderCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateOrder(ISender sender, int id, UpdateOrderCommand command)
    {
        if (id != command.OrderId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteOrder(ISender sender, int id)
    {
        await sender.Send(new DeleteOrderCommand(id));
        return Results.NoContent();
    }
}