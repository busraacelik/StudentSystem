using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.VMs
{
    public class RegisterVm
    {
        [Required(ErrorMessage = "Ad alanı zorunludur!")]
        [DisplayName("Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçerli formatta girmediniz!")]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
