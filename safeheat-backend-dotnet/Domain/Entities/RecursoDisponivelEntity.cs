using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace safeheat_backend_dotnet.Domain.Entities;

[Table("SH_RECURSOS_DISPONIVEIS")]
public class RecursoDisponivelEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } // Ex: Água, Cobertor, Colchão

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }

    [Required]
    public int AbrigoId { get; set; }

    [ForeignKey("AbrigoId")]
    public AbrigoEntity Abrigo { get; set; }
}
