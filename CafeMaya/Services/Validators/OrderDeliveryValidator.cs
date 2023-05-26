using CafeMaya.Models;
using FluentValidation;

namespace CafeMaya.Services.Validators;

public class OrderDeliveryValidator : AbstractValidator<OrderDelivery>
{
    public OrderDeliveryValidator()
    {
        RuleFor(o => o.Address).NotEmpty().WithMessage("Адрес не должен быть пустым.")
            .MinimumLength(5)
            .WithMessage("Адрес доставки не может быть меньше 5 символов.");
    }
}