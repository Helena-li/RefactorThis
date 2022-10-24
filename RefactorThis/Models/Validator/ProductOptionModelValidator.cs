using FluentValidation;

namespace RefactorThis.Models.Validator;

public class ProductOptionModelValidator: AbstractValidator<ProductOptionModel>
{
    public ProductOptionModelValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);

        RuleFor(x => x.Description).MaximumLength(500);
    }
}