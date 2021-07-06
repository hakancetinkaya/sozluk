using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
  public  class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
 RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcı adresi boş olamaz");
 RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş olamaz");
 RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
 RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriş yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakterde fazla giriş yapmayın");
        }
       
    }
}
