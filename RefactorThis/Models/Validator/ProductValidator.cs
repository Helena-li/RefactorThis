using FluentValidation;

namespace RefactorThis.Models.Validator;

public class ProductValidator: AbstractValidator<ProductModel>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);

        RuleFor(x => x.Description).MaximumLength(500);

        RuleFor(x => x.Price).NotNull().NotEmpty();

        RuleFor(x => x.DeliveryPrice).NotNull().NotEmpty();
    }
}