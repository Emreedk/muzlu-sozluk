using ContentProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz");
            //RuleFor(x => x.Category.CategoryName).().WithMessage("Kategori seçimi yapmalısınız");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.HeadingName).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");
            
            
        }
    }
}
