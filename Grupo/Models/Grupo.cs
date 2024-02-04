using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sl.GrupoAPI.Models
{

    [Table("sl_grupos")]
    public class Grupo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
    }
}
