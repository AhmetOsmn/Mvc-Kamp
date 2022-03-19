using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş olamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj kısmı boş olamaz.");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapabilirsiniz.");
        }
    }
}
