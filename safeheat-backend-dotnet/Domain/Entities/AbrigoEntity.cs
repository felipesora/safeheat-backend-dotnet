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
    public string CEP { get; set; }

    [Required]
    public string Rua { get; set; }

    [Required]
    public string Numero { get; set; }

    [Required]
    public string Bairro { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Estado { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CapacidadeTotal { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int OcupacaoAtual { get; set; }

    public ICollection<RecursoDisponivelEntity> RecursosDisponiveis { get; set; } = new List<RecursoDisponivelEntity>();

}
