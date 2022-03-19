using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(25).WithMessage("Kategori adı en fazla 25 karakter olabilir.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş olamaz.");
        }
    }
}
