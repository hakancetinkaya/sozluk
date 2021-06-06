using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
  public  class CantactValidator : AbstractValidator<Contact>
    {
        public CantactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adı boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Message).MaximumLength(20).WithMessage("Lütfen 20 den fazla karakter girmeyiniz");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Lütfen 3 den fazla karakter giriniz");
        }
    }
}
