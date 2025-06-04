using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace safeheat_backend_dotnet.Application.DTOs;

public class AbrigoDto
{
    [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatorio")]
    public string Nome { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(CEP)} é obrigatorio")]
    public string CEP { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Rua)} é obrigatorio")]
    public string Rua { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Numero)} é obrigatorio")]
    public string Numero { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Bairro)} é obrigatorio")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Cidade)} é obrigatorio")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Estado)} é obrigatorio")]
    public string Estado { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(CapacidadeTotal)} é obrigatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "A Capacidade Total deve ser maior que 0")]
    public int CapacidadeTotal { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(OcupacaoAtual)} é obrigatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "A Ocupação Atual deve ser maior ou igual à 0")]
    public int OcupacaoAtual { get; set; }
}
