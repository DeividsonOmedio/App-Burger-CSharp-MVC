using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Areas.Identity.Data
{
    public class UserModel : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres")]
        public string UserName { get; set; }
        [MaxLength(15, ErrorMessage = "O tamanho máximo é de 15 caracteres")]
        public string PhoneNumber { get; set; }
    }
}
