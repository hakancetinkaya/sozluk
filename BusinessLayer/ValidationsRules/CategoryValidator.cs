using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        //Fluent Validation kullanımı
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş olamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 den fazla karakter girmeyiniz");

        }
    }
}
