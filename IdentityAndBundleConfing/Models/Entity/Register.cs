using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityAndBundleConfing.Models
{
    public class Register
    {
        [Required]
        [Display(Name ="Ad")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "KullaniciAdi")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Sifre")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Sifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}