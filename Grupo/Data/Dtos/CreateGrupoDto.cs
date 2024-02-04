using System.ComponentModel.DataAnnotations;

namespace Sl.GrupoAPI.Data.Dtos
{
    public class CreateGrupoDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string? Nome { get; set; }
    }
}
