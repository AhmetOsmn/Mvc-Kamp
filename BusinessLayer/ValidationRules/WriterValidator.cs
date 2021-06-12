using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş olamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş olamaz");
            RuleFor(x => x.WriterAbout).Must(ContainA).WithMessage("Hakkında kısmında 'a' harfi bulunmak zorunda");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 giriniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyad 50 karakterden fazla olamaz");
        }

        private bool ContainA(string arg)
        {
            return arg.ToLower().Contains('a');
        }
    }
}
