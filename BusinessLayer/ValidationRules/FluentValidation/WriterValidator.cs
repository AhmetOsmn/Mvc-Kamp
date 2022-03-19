using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş olamaz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı en az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakter olabilir.");


            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazarın hakkında kısmı boş olamaz.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Yazarın hakkında kısmı en fazla 100 karakter olabilir.");
            RuleFor(x => x.WriterAbout).Must(ContainE).WithMessage("Yazarın hakkında kısmı mutlaka 'e' harfi içermelidir.");

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazarın ünvan kısmı boş olamaz.");
            RuleFor(x => x.WriterTitle).MinimumLength(5).WithMessage("Yazar ünvan kısmı en az 5 karakter olmalıdır.");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazarın ünvan kısmı en fazla 50 karakter olabilir.");
        }

        private bool ContainE(string writerAbout)
        {
            return writerAbout.ToLower().Contains('e');
        }

    }
}
