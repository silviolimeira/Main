using System.ComponentModel.DataAnnotations;

namespace Sl.GrupoAPI.Data.Dtos
{
    public class ReadGrupoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
