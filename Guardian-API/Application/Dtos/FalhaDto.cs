using System.ComponentModel.DataAnnotations;

namespace Guardian_API.Application.Dtos
{
    public class FalhaDto
    {
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "A descrição da falha é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição da falha deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O status da falha é obrigatório.")]
        [StringLength(50, ErrorMessage = "O status da falha deve ter no máximo 50 caracteres.")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "A prioridade da falha é obrigatória.")]
        [StringLength(20, ErrorMessage = "A prioridade da falha deve ter no máximo 20 caracteres.")]
        public string Prioridade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo da falha é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo da falha deve ter no máximo 100 caracteres.")]
        public string Tipo { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "A equipe responsável deve ter no máximo 100 caracteres.")]
        public string EquipeManutencaoResponsavel { get; set; } = string.Empty;

        public DateTime? DataResolucao { get; set; }

        [Required(ErrorMessage = "A lista de aerogeradores associados é obrigatória.")]
        public List<int> AerogeradorIds { get; set; } = new List<int>();
    }
}
