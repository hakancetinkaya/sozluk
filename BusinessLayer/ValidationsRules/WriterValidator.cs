using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        //Fluent Validation kullanımı
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısmı boş olamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen 50 den fazla karakter girmeyiniz");

        }
    }
}
