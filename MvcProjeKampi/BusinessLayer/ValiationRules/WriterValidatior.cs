﻿using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValiationRules
{
    public class WriterValidatior : AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soy adını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz.");
           // RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Hakkımdada en az 1 a harfi olmak zorunda.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişim yapın.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayın.");
        }

    }
}
