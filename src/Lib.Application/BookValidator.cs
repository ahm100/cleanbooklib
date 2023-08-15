using FluentValidation;
using lib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Application
{
    // baraye post va kolan crud
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.price)
               .NotEmpty().WithMessage("{TotalPrice} is required.")
               .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
            RuleFor(x => x.title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.publishDate).NotEmpty().MaximumLength(20);
            RuleFor(x => x.isbn).NotEmpty().MaximumLength(20);
        }
    }
}
