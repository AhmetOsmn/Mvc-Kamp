using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Kullanıcı adı en az 2 karakter olmalı");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu içeriği en az 3 karakter olmalı");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu içeriği en fazla 100 harften oluşmalı");
        }
    }
}
