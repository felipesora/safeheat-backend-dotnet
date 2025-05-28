using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace safeheat_backend_dotnet.Domain.Entities;

[Table("SH_REGISTOS_ENTRADA")]
public class RegistroDeEntradaEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomePessoa { get; set; }

    public DateTime DataEntrada { get; set; } = DateTime.Now;

    public int AbrigoId { get; set; }

    // Propriedade de navegação
    [ForeignKey("AbrigoId")]
    public AbrigoEntity Abrigo { get; set; }
}
