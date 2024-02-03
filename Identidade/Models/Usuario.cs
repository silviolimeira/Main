using Microsoft.AspNetCore.Identity;

namespace IdentidadeAPI.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        public Usuario() : base()
        {
            
        }
    }
}
