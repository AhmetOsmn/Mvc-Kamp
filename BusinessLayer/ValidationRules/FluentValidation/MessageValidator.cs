using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz");
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici adresi boş olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş olamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj kısmı boş olamaz.");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");

            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapabilirsiniz.");
        }
    }
}
