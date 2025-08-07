using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using E_Commerce.Application.ViewModels.Products;
using E_Commerce.Domain.Entities;

using FluentValidation;

namespace E_Commerce.Application.Validator.Products
{
    public class CreateProductValidatior : AbstractValidator<Vm_CreateProduct>
    {
        public CreateProductValidatior()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("The product name can not be null. Please, enter the product name.")
                .NotEmpty().WithMessage("Please, enter the product name.")
                .MaximumLength(150).WithMessage("Please enter a product name no longer than 150 characters.")
                .MinimumLength(5).WithMessage("Please enter a product name that is at least 5 characters long.");

            RuleFor(p => p.Stock)
                .NotNull().WithMessage("Stock value cannot be null.")
                .NotEmpty().WithMessage("Stock value cannot be empty.")
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be 0 or greater.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price value cannot be null.")
                .NotEmpty().WithMessage("Price value cannot be empty.")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be 0 or greater.");
        }
    }
}
