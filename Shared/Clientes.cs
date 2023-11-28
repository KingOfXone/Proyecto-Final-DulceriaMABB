using System.ComponentModel.DataAnnotations;

namespace DulceriaMABB.Shared
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public String? Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public String? Apellido { get; set; }
        [Required(ErrorMessage = "El Telefono es requerido")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "El Telfono debe tener 10 digitos numéricos")]
        public String? Telefono { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public String? Correo { get; set; }
        [Required(ErrorMessage = "La cedula es requerida")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "La cedula debe tener 11 digitos numéricos")]
        public String? Cedula { get; set; }
        public Double Balance { get; set; }
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }
    }
}
