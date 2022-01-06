using ContentProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresini boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayın");
        }
       
    }
}
