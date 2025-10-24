using System.ComponentModel.DataAnnotations;

namespace proyect_prestamo.Modelos
{
    //Objeto que recibimos desde Flutter
    public class RegistrosUsuarios
    {

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
