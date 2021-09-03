using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace İzinFormu.Models
{
    public class User
    {


        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        public string UserName { get; set; }


        [DisplayName("Şifre")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Şifre 6-12 karakter arası olmalı!")]
        public string Password { get; set; }
    }
}
