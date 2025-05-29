using System.ComponentModel.DataAnnotations;

namespace safeheat_backend_dotnet.Application.Dtos;

public class RecursoDisponivelDto
{
    [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(Quantidade)} é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior ou igual a 0")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = $"Campo {nameof(AbrigoId)} é obrigatório")]
    public int AbrigoId { get; set; }
}
