using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.VMs
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Email alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçerli formatta girmediniz!")]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
