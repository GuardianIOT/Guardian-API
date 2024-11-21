using Guardian_API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Guardian_API.Application.Dtos
{
    public class AerogeradorDto
    {
        [Required(ErrorMessage = "O modelo do aerogerador é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "A tecnologia deve ter no máximo 100 caracteres.")]
        public string Tecnologia { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade em MW é obrigatória.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "A capacidade em MW deve ser maior que zero.")]
        public double CapacidadeMW { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "A altura do mastro deve ser maior que zero.")]
        public double AlturaMastro { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "A velocidade de corte deve ser maior que zero.")]
        public double VelocidadeCorte { get; set; }

        [Required(ErrorMessage = "O status de operação é obrigatório.")]
        [StringLength(50, ErrorMessage = "O status de operação deve ter no máximo 50 caracteres.")]
        public string StatusOperacao { get; set; } = string.Empty;

        [Range(0.1, double.MaxValue, ErrorMessage = "O diâmetro do motor deve ser maior que zero.")]
        public double DiametroMotor { get; set; }

        [DataType(DataType.Date, ErrorMessage = "A data de instalação deve ser uma data válida.")]
        public DateTime DataInstalacao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "A data de garantia deve ser uma data válida.")]
        public DateTime Garantia { get; set; }
        public int? ParqueId { get; set; }
    }
}
