// namespace: AMSeCommerce.Application.UseCases.Product.Register

using AMSeCommerce.Communication.Request.Product;
using FluentValidation;

namespace AMSeCommerce.Application.UseCases.Product;

public class ProductValidator : AbstractValidator<RequestProductJson>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("StockQuantity cannot be negative");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("CategoryId is required");

        RuleFor(x => x.Image)
            .NotNull()
            .WithMessage("Image is required");
    }
}