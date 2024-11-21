using Guardian_API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Guardian_API.Application.Dtos
{
    public class TorreDto
    {
        [Required(ErrorMessage = "O nome da torre é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        public LocalizacaoEntity? Localizacao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "A data de instalação deve ser uma data válida.")]
        public DateTime DataInstalacao { get; set; }

        [Required(ErrorMessage = "O status de operação é obrigatório.")]
        [StringLength(50, ErrorMessage = "O status de operação deve ter no máximo 50 caracteres.")]
        public string StatusOperacao { get; set; } = string.Empty;

        [DataType(DataType.Date, ErrorMessage = "A data da última leitura deve ser uma data válida.")]
        public DateTime UltimaLeitura { get; set; }
    }
}
