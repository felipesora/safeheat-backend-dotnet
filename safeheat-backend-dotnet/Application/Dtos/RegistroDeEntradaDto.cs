using System.ComponentModel.DataAnnotations;

namespace safeheat_backend_dotnet.Application.Dtos;

public class RegistroDeEntradaDto
{
    [Required(ErrorMessage = $"Campo {nameof(NomePessoa)} é obrigatorio")]
    public string NomePessoa { get; set; }

    public DateTime DataEntrada { get; set; } = DateTime.Now;

    [Required(ErrorMessage = $"Campo {nameof(AbrigoId)} é obrigatorio")]
    public int AbrigoId { get; set; }
}
