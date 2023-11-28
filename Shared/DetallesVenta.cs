using System.ComponentModel.DataAnnotations;

namespace DulceriaMABB.Shared
{
    public class DetallesVenta
    {
        [Key]
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public Double PrecioTotal { get; set; }
        public Double GanaciasTotal { get; set; }
    }
}
