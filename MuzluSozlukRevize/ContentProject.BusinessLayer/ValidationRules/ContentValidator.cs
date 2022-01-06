using ContentProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.ValidationRules
{
    public class ContentValidator:AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x => x.ContentValue).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.ContentValue).MinimumLength(20).WithMessage("En az 20 karakter girişi yapınız");
        }
    }
}
