namespace OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

public class NewMenuItemDto
{
    public int? MenuItemId { get; init; }
    
    public string? Name { get; init; }

    public int Price { get; init; }

}