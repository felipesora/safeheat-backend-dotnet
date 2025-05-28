using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace safeheat_backend_dotnet.Domain.Entities;

public class RegistroDeEntradaEntity
{
    public int Id { get; set; }

    [Required]
    public string NomePessoa { get; set; }

    public DateTime DataEntrada { get; set; } = DateTime.Now;

    // Chave estrangeira
    public int AbrigoId { get; set; }

    // Propriedade de navegação
    [ForeignKey("AbrigoId")]
    public AbrigoEntity Abrigo { get; set; }
}
