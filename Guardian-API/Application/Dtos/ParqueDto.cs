using Guardian_API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Guardian_API.Application.Dtos
{
    public class ParqueDto
    {
        [Required(ErrorMessage = "O nome do parque é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do parque deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ano de inauguração é obrigatório.")]
        public DateTime AnoInauguracao { get; set; }

        public int? LocalizacaoId { get; set; }

        [Required(ErrorMessage = "A área do parque em Km² é obrigatória.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "A área deve ser maior que zero.")]
        public double AreaKm { get; set; }

        [StringLength(200, ErrorMessage = "A tecnologia deve ter no máximo 200 caracteres.")]
        public string Tecnologia { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "O status de operação deve ter no máximo 50 caracteres.")]
        public string StatusOperacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de aerogeradores é obrigatório.")]
        [Range(1, 1, ErrorMessage = "O número de aerogeradores deve ser maior ou igual a 1.")]
        public int NumeroAerogeradores { get; set; }

        public List<int> AerogeradorIds { get; set; }

        public LocalizacaoEntity? Localizacao { get; set; }
    }
}
