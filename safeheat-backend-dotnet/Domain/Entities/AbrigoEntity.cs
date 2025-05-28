using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace safeheat_backend_dotnet.Domain.Entities;

[Table("SH_ABRIGOS")]
public class AbrigoEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CapacidadeTotal { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int CapacidadeAtual { get; set; }

    // Relacionamento 1:N
    public ICollection<RegistroDeEntradaEntity> RegistrosDeEntrada { get; set; }
}
