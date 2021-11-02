using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{ // view'a göre model oluşturduk.
    public class AccountUserVM
    {
        [Required]
        [Display(Name ="Ad Soyad")]
        public string FullName { get; set; }
        [Required]
        [Display(Name ="Email Adresiniz")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Formatı")] // email formunda olmalıdır..
        public string Email { get; set; }
        [Required]
        [Display(Name ="Şifreniz")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Şifre Tekrarınız")]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil !!")] // compare bir validationdır. Bu property değerini belirtdiğimiz diğer property değeri ile belirleriz.
        public string Password2 { get; set; }
    }
}
