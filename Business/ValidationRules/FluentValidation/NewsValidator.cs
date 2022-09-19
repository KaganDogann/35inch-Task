using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsValidator: AbstractValidator<TheNews>
    {
        public NewsValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty().MinimumLength(20);
            RuleFor(c => c.Genre).NotEmpty();

        }
    }
}
