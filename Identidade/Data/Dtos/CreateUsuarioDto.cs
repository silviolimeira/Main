using System.ComponentModel.DataAnnotations;

namespace IdentidadeAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

    }
}
