using OrderSystem.Application.Common.Interfaces;

namespace OrderSystem.Application.MenuItems.Commands.CreateMenuItem;

public class CreateMenuItemCommandValidator : AbstractValidator<CreateMenuItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMenuItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.NewMenuItem.Name)
            .NotEmpty()
            .MaximumLength(30)
            .MustAsync(BeUniqueName)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
        
        RuleFor(v => v.NewMenuItem.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
        
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.MenuItems.AllAsync(menuItem => menuItem.Name != name, cancellationToken);
    }
}
