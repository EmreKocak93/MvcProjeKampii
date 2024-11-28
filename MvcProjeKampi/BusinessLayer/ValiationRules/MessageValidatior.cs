using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValiationRules
{
    public class MessageValidatior:AbstractValidator<Message>
    {
        public  MessageValidatior()
        {
            //Girilen bir mail adresinin geçerli bir mail olup olmadığını araştır
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
            //RuleFor(x => x.Subject).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz.");
            // RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Hakkımdada en az 1 a harfi olmak zorunda.");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişim yapın.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayın.");
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçersiz mail adresi");
        }
       
    }
}
