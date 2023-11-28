using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DulceriaMABB.Shared
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        [Required(ErrorMessage = "El Cliente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El Cliente es Requerido")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El Concepto es requerido")]
        public String? Concepto { get; set; }
        [Required(ErrorMessage = "El Tipo de venta es requerido")]
        public String? TipoVenta { get; set; }
        public Double Monto { get; set; }
        public Double Ganacias { get; set; }
        public Double Balance { get; set; }
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<DetallesVenta> detallesVentas { get; set; } = new List<DetallesVenta>();
    }
}
