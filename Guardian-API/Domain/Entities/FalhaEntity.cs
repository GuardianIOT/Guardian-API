using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardian_API.Domain.Entities
{
    [Table("TB_FALHA")]
    public class FalhaEntity
    {
        [Key]
        public int Id { get; set; }
        public List<AerogeradorEntity> Aerogeradores { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string Tipo { get; set; }
        public string EquipeManutencaoResponsavel { get; set; }
        public DateTime? DataResolucao { get; set; }
    }
}
