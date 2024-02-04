using System.ComponentModel.DataAnnotations;

namespace Sl.GrupoAPI.Data.Dtos
{
    public class UpdateGrupoDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string? Nome { get; set; }
    }
}
