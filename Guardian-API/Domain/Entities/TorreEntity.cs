using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Guardian_API.Domain.Entities
{
    [Table("TB_TORRE")]
    public class TorreEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? LocalizacaoId { get; set; }
        [ForeignKey("LocalizacaoId")]
        public LocalizacaoEntity? Localizacao { get; set; }
        public DateTime DataInstalacao { get; set; }
        public string StatusOperacao { get; set; } = string.Empty;
        public DateTime UltimaLeitura { get; set; }
    }
}
