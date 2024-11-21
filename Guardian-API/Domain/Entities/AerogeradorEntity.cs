using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardian_API.Domain.Entities
{
    [Table("TB_AEROGERADOR")]
    public class AerogeradorEntity
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Tecnologia { get; set; } = string.Empty;
        public double CapacidadeMW { get; set; }
        public double AlturaMastro { get; set; }
        public double VelocidadeCorte { get; set; }
        public string StatusOperacao { get; set; } = string.Empty;
        public double DiametroMotor { get; set; }
        public DateTime DataInstalacao { get; set; }
        public DateTime Garantia { get; set; }
    }
}
