using System.ComponentModel.DataAnnotations;

namespace proyect_prestamo.Modelos
{
    public class Usuarios
    {
        //Clve primaria
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //Halmacenamos el hash, no la contraseña en texto plano
        public string Password { get; set; } = string.Empty;
    }
}
