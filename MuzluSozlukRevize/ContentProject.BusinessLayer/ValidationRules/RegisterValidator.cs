using ContentProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.ValidationRules
{
    public class RegisterValidator:AbstractValidator<Writer>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim Alanı Boş geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyad Alanı Boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Alanı Boş geçilemez");
            RuleFor(x => x.WriterUsername).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Alanı Boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkınızda Alanı Boş geçilemez");
            //RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Lütfen Resim Ekleyiniz");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli Bir Mail Adresi Giriniz");
        }
    }
}
