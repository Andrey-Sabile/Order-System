using OrderSystem.Application.MenuItems.Commands;
using OrderSystem.Application.MenuItems.Queries;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Web.Endpoints;

public class MenuItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetMenuItems)
            .MapGet(GetMenuItemById, "{id}")
            .MapPost(CreateMenuItem)
            .MapPut(UpdateMenuItem, "{id}")
            .MapDelete(DeleteMenuItem, "{id}");
    }

    public async Task<IList<MenuItem>> GetMenuItems(ISender sender)
    {
        return await sender.Send(new GetMenuItemsQuery());
    }

    public async Task<MenuItem> GetMenuItemById(ISender sender, [AsParameters] GetMenuItemByIdQuery query)
    {
        if (query.Id < 0)
            throw new ArgumentOutOfRangeException("Id must not be negative", nameof(query.Id));

        return await sender.Send(query);
    }

    public async Task<int> CreateMenuItem(ISender sender, CreateMenuItemCommand command)
    {
        if (String.IsNullOrWhiteSpace(command.Name))
            throw new ArgumentNullException("Name must not be null or empty", nameof(command.Name));

        if (command.Price < 0)
            throw new ArgumentOutOfRangeException("Price must not be negative", nameof(command.Price));

        return await sender.Send(command);
    }

    public async Task<IResult> UpdateMenuItem(ISender sender, int id, UpdateMenuItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteMenuItem(ISender sender, int id)
    {
        await sender.Send(new DeleteMenuItemCommand(id));
        return Results.NoContent();
    }
}