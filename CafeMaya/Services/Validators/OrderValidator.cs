using CafeMaya.Models;
using FluentValidation;

namespace CafeMaya.Services.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.Delivery)
            .SetValidator(new OrderDeliveryValidator()!)
            .When(o => o.Delivery != null)
            .WithMessage("Адрес доставки должен быть указан в случае если заказ предназначен для доставки.");
        
        RuleFor(o => o.Items)
            .NotEmpty()
            .WithMessage("Для формирования заказа нужно добавить блюда.");
    }
}