using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardian_API.Domain.Entities
{
    [Table("TB_LOCALIZACAO")]
    public class LocalizacaoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Regiao { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
