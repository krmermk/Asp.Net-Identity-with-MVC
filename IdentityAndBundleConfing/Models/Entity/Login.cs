using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityAndBundleConfing.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "KullaniciAdi")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Sifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}