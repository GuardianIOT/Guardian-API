using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardian_API.Domain.Entities
{
    [Table("TB_PARQUE")]
    public class ParqueEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime AnoInauguracao { get; set; }
        public int? LocalizacaoId { get; set; }
        public double AreaKm { get; set; }
        public string Tecnologia { get; set; } = string.Empty;
        public string StatusOperacao { get; set; } = string.Empty;
        public int NumeroAerogeradores { get; set; }
        public List<AerogeradorEntity> Aerogeradores { get; set; } = new List<AerogeradorEntity>();

        [ForeignKey("LocalizacaoId")]
        public LocalizacaoEntity? Localizacao { get; set; }
    }
}
