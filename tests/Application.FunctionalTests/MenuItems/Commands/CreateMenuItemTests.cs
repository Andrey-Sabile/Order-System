using OrderSystem.Application.Common.Exceptions;
using OrderSystem.Application.MenuItems.Commands.CreateMenuItem;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Application.FunctionalTests.MenuItems.Commands;

using static Testing;

public class CreateMenuItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateMenuItemCommand();

        await FluentActions.Invoking(() => SendAsync(command))
            .Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateMenuItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateMenuItemCommand
        {
            Name = "New Item",
            Price = 10
        };

        var menuItemId = await SendAsync(command);

        var menuItem = await FindAsync<MenuItem>(menuItemId);

        menuItem.Should().NotBeNull();
        menuItem!.Name.Should().Be(command.Name);
        menuItem.CreatedBy.Should().Be(userId);
        menuItem.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        menuItem.LastModifiedBy.Should().Be(userId);
        menuItem.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
