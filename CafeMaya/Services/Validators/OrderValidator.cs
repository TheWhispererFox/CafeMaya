using CafeMaya.Models;
using FluentValidation;

namespace CafeMaya.Services.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.Address)
            .NotEmpty().WithMessage("Адрес не должен быть пустым.")
            .MinimumLength(5).WithMessage("Адрес доставки не может быть меньше 5 символов.")
            .When(o => o.IsForDelivery);

        RuleFor(o => o.ClientPhone)
            .NotEmpty().WithMessage("Телефон должен быть предоставлен")
            .Matches("([\\+]?)([0-9]{1,2}\\([0-9]{3}\\)[0-9]{3}\\-[0-9]{2}\\-[0-9]{2})").WithMessage("Телефон должен быть 11 символов (если без знака +) или 12 символов (если со знаком +) и должен состоять из цифр")
            .When(o => o.IsForDelivery);

        RuleFor(o => o.Items)
            .NotEmpty().WithMessage("Для формирования заказа нужно добавить блюда.");
    }
}