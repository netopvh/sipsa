using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha requerida"), DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
