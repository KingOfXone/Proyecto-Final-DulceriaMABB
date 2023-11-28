using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace DulceriaMABB.Shared
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public String? Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public String? Descripcion { get; set; }
        [Required(ErrorMessage = "El Costo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El Costo debe ser mayor a 0")]
        public Double Costo { get; set; }
        [GreaterThan("Costo", ErrorMessage = "El precio debe ser mayor que el costo")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El Precio debe ser mayor a 0")]
        public Double Precio { get; set; }
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "La fecha Es Requerida")]
        public DateTime Fecha { get; set; }
    }
}
