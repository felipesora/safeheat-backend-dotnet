using System.ComponentModel.DataAnnotations;

namespace safeheat_backend_dotnet.Application.DTOs;

public class AbrigoDto
{
    [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatorio")]
    public string Nome { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Endereco)} é obrigatorio")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Cidade)} é obrigatorio")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(CapacidadeTotal)} é obrigatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "A Capacidade Total deve ser maior que 0")]
    public int CapacidadeTotal { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(CapacidadeAtual)} é obrigatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "A Capacidade Total deve ser maior ou igual à 0")]
    public int CapacidadeAtual { get; set; }
}
